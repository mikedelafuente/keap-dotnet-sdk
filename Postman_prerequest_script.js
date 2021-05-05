// Place this in your Postman Prerequisite file to have it refresh tokens
var needsRefresh = false;

// Is the token valid
var accessToken = pm.environment.get("OAuth_AccessToken");
var refreshToken = pm.environment.get("OAuth_RefreshToken");

if (!refreshToken) {
    console.log("No refresh token detected. Exiting. Please set the OAuth_RefreshToken in the Environmental variables.");
    return;
} 

if (!accessToken) {
    needsRefresh = true;
}

var originalExpirationDate = pm.environment.get("OAuth_TokenExpiration");

var parsedExpirationDate = null;

if (originalExpirationDate) {
      parsedExpirationDate = new Date(originalExpirationDate);
 
     if (parsedExpirationDate <= Date.now()) {
        needsRefresh = true;
    }
} else {
    console.log("No expiration date set");
    needsRefresh = true;
}


if (!needsRefresh) {
    // console.log("Access token is still valid");
    return;
}

console.log("Attempting to refresh token.");
    

var authToken = pm.environment.get("OAuth_ClientId") + ':' + pm.environment.get("OAuth_Secret");
var base64Auth = btoa(authToken)

pm.sendRequest({
      url: pm.environment.get("OAuth_TokenUrl"), 
      method: 'POST',
      header: {
        'Accept': 'application/json',
        'Content-Type': 'application/x-www-form-urlencoded',
        'Authorization': 'Basic ' + base64Auth 
      },
      body: {
          mode: 'urlencoded',
          urlencoded: [
            {key: "grant_type", value: "refresh_token", disabled: false},
            {key: "refresh_token", value: pm.environment.get("OAuth_RefreshToken"), disabled: false}            
        ]
      }
  }, function (err, res) {
      if (err) {
          console.warn("Error refreshing the token: " + err.toString())
          return;
      }

      if (res.code >= 300) {
          console.warn("Failed to get a new refresh token");
          console.warn(res);
          return;
      }
       // console.log(res);
       // console.log(res.json());
        pm.environment.set("OAuth_RefreshToken", res.json().refresh_token);

        pm.environment.set("OAuth_AccessToken", res.json().access_token);

        var expiresIn = res.json().expires_in;
        
        pm.environment.set("OAuth_TokenCreated", new Date().toString());

        var newTokenExpiration = new Date();
        
        newTokenExpiration.setSeconds(newTokenExpiration.getSeconds() + expiresIn);

       // console.log("New Expiration: " + newTokenExpiration.toString());

       pm.environment.set("OAuth_TokenExpiration", newTokenExpiration.toString());

        console.log("Updated the refresh token");
  });

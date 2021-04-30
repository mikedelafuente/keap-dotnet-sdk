# Keap SDK for .NET

## Needed features
* OAuth Login hooks
* 429 notifications
* Event Hub for logs and other events
* Auto-refresh of tokens
* Storage of keys using a provider model (IKeyStorage)
* Ability to leverage all v1 or v2
* Calls to XML-RPC
* Abstraction that would allow a shift from v1 to v2 with very low friction

## Areas to be implemented
* Authentication

### REST
* Account Info
  * Retrieve account profile
  * Updates an account profile
* Affiliate
  * List Affiliates
  * Create an affiliate
  * List Affiliate clawbacks
  * List Affiliate payments
  * Retrieve an affiliate
  * List Commissions
  * Retrieve Affiliate Model
  * List Commission Programs
  * List Affiliate Redirects
  * List affiliate summaries
* Appointment
  * List Appointments
  * Create an Appointment
  * Delete an Appointment
  * Retrieve an Appointment
  * Update an Appointment
  * Replace an Appointment
  * Retrieve Appointment Model
  * Create a Custom Field
* Campaign
  * List Campaigns
  * Retrieve a Campaign
  * Remove Multiple from Campaign Sequence
  * Add Multiple to Campaign Sequence
  * Remove from Campaign Sequence
  * Add to Campaign Sequence
  * Achieve API Goal
* Company
  * List Companies
  * Create a Company
  * Retrieve a Company
  * Update a Company
  * Retrieve Company Model
  * Update a Company
* Contact
  * List Contacts
  * Create a Contact
  * Create or Update a Contact
  * Delete a Contact
  * Update a Contact
  * Retrieve Credit Cards
  * Create a Credit Card
  * List Emails
  * Create an Email Record
  * Remove Applied Tags
  * List Applied Tags
  * Apply Tags
  * Remove Applied Tag
  * Retrieve a Contact
  * Retrieve Contact Model
  * Create a Custom Field
  * Delete a Contact
  * Update a Contact
* Ecommerce
  * List Orders
  * Create an Order
  * Delete an Order
  * Retrieve an Order
  * Create an Order Item
  * Delete an Order Item
  * Replace an Order Pay Plan
  * Retrieve Order Payments
  * Create a Payment
  * Retrieve Order Transactions
  * Retrieve Custom Order Model
  * List Subscriptions
  * Create Subscription
  * Retrieve Subscription Model
  * List Transactions
  * Retrieve a Transaction
* Email
  * List Emails
  * Create an Email Record
  * Delete an Email Record
  * Retrieve an Email
  * Update an Email Record
  * Send an Email
  * Create a set of Email Records
  * Un-sync a batch of Email Records
* Email Address
  * Replace an Email Address
* File
  * List Files
  * Upload File
  * Delete File
  * Retrieve File
  * Replace File
* Locale
  * List Countries
  * List a Country's Provinces
* Merchant
  * List Merchants
* Note
  * List Notes
  * Create a Note
  * Delete a Note
  * Retrieve a Note
  * Update a Note
  * Replace a Note
  * Retrieve Note Model
  * Create a Custom Field
* Opportunity
  * List Opportunities
  * Create an Opportunity
  * Replace an Opportunity
  * Retrieve an Opportunity
  * Update an Opportunity
  * Retrieve Opportunity Model
  * List Opportunity Stage Pipeline
* Product
  * List Products
  * Create a Product
  * Delete a Product
  * Retrieve a Product
  * Update a Product
  * Delete a product image
  * Upload a product image
  * Create a Product Subscription
  * Delete a Product Subscription
  * Retrieve a Product Subscription
  * Retrieve Synced Products
* REST Hooks
  * List Hook Event Types
  * Create a Hook Subscription
  * Verify a Hook Subscription
  * Verify a Hook Subscription, Delayed
  * List Stored Hook Subscriptions
  * Retrieve a Hook Subscription
  * Update a Hook Subscription
  * Delete a Hook Subscription
* Setting 
  * Retrieve application configuration
  * Retrieve application status
  * List Contact types
* Tags
  * List Tags
  * Create Tag
  * Retrieve a Tag
  * List Tagged Companies
  * Remove Tag from Contacts
  * List Tagged Contacts
  * Apply Tag to Contacts
  * Remove Tag from Contact
  * Create Tag Category
* Task
  * List Tasks
  * Create a Task
  * Delete a Task
  * Retrieve a Task
  * Update a Task
  * Replace a Task
  * Retrieve Task Model
  * Create a Custom Field
  * Search Tasks
* User Info
  * Retrieve User Info
* Users
  * List Users
  * Create a User
  * Get User email signature

### XML-RPC 
* Authentication
  * Request Permission
  * Request an Access Token
  * Refresh an Access Token
* Affiliate
  * Retrieve Clawbacks
  * Retrieve Commissions
  * Retrieve Payments
  * Retrieve Redirect Links
  * Retrieve Summary
  * Retrieve Running Totals
* Affiliate Program
  * Retrieve All Programs
  * Retrieve a Program's Affiliates
  * Retrieve an Affiliate's Programs
  * Retrieve Program Resources
* Contact
  * Create a Contact
  * Create & Check for Duplicate
  * Retrieve a Contact
  * Update a Contact
  * Merge Contacts
  * Search by Email
  * Add Tag
  * Remove Tag
  * Add to Follow-up Sequence
  * Next Follow-up Sequence Step
  * Execute Follow-up Step
  * Pause Follow-up Sequence
  * Resume Follow-up Sequence
  * Remove from Follow-up Sequence
  * Link Contacts
  * Unlink Contacts
  * List Linked Contacts
  * Run Action Sequence
* Data
  * Retrieve information about a user
  * Create a Record
  * Retrieve a Record
  * Find by Field
  * Query a Data Table
  * Update a Record
  * Delete a Record
  * Count Records
  * Create a Custom Field
  * Update a Custom Field
  * Retrieve Appointment's iCal
  * Retrieve Application Setting
* Discount
  * Create Order Discount
  * Retrieve Order Discount
  * Create Subscription Trial
  * Retrieve Subscription Trial
  * Create a Shipping Discount
  * Retrieve a Shipping Discount
  * Create Product Discount
  * Retrieve a Product Discount
  * Create a Category Discount
  * Retrieve a Category Discount
  * Retrieve Discount's Assignments
  * Assign Product to Discount
* Email
  * Opt-in an Email Address
  * Opt-out an Email Address
  * Retrieve Opt-in Status
  * Create Email Template
  * Retrieve Email Template
  * Update Email Template
  * Send From Template
  * Send an Email
  * Retrieve Merge Fields
  * Log Sent Email
  * Introduction
  * Making Requests
  * Helper Libraries
  * Additional Languages
* File
  * Upload a File
  * Retrieve a File
  * Retrieve Download URL
  * Replace a File
  * Rename a File
* Funnel
  * Achieve a Goal
* Invoice
  * Create an Invoice
  * Pay an Invoice
  * Retrieve Invoice Payments
  * Retrieve Invoice Amount Due
  * Add an Item to an Order by Invoice
  * Add Manual Payment
  * Add a Commission to an Invoice
  * Calculate Invoice Tax
  * Delete an Invoice
  * Create a Contact Subscription
  * Create a Subscription Invoice
  * Update Subscription Billing Date
  * Delete a Subscription
  * Validate a New Credit Card
  * Validate an Existing Credit Card
  * Retrieve Credit Card
  * Retrieve Available Payment Options
  * Create Custom Recurring Payment
Order
  * Create an Order
Product
  * Retrieve Inventory
  * Increment Inventory
  * Decrement Inventory
  * Increase Inventory
  * Decrease Product Inventory
  * Deactivate a Credit Card
Search
  * Retrieve Available Fields
  * Retrieve Search Report
  * Retrieve Partial Report
  * Retrieve Available Quick Searches
  * Retrieve Default Quick Search
  * Retrieve Quick Search
Shipping
  * Retrieve Available Shipping Options
  * Retrieve Weight-Based Shipping Options
  * Retrieve Flat Rate Shipping Options
  * Retrieve Product Shipping Options
  * Retrieve Order Shipping Options
  * Retrieve Order Quantity Shipping Options
  * Retrieve Order Shipping Ranges
  * Retrieve UPS Shipping Option
Webform
  * Retrieve a Form's HTML
  * Retrieve Webform IDs


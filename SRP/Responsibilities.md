## 1 . AppointmentDesk class
resopnsible of make new appoinments

1. IsWithinBusinessHours is responsible for ask is it within business hours
and this function make problem 
because when i need to change business hours 
i must go to AppointmentDesk class

2. FindNextSlot is resoponsible for find next slot
and this function is good to be here

3. TryBook is responsible for return true if i can book and false if i can't
and this function is good to be here

4. ToIcs is responsible for return the string format of patient name and clinician
and date
and this function make problem here 
because when i need to change the string format
i must go to AppointmentDesk class


5. SmsReminder is responsible for return sms message by clinic phone
and this function make problem here
because when i need to change the sms format
i must go to AppointmentDesk class

6. Align is responsible align the time
and this function is good to be here


## 2. CheckoutBasket class

1. AddLine is responsible for add new line in the list
and this function is good to be here

2. ApplyCouponText is responsible for applying the copuon text
and this function is good to be here

3. EnableGiftWrap is responsible enable for enabling the gift wrap
and this function is good to be here

4. SubTotal is responsible get the total price of lines
and this function is good to be here 

5. DiscountAmount is responsible to get the discount amount by parsing the coupon raw
and this function make problem here
because when i need to change the discount logic
i must go to CheckoutBasket class

6. GrandTotal is responsible to get the total amount by subtract the subtotal minus the discount amount
and this function make problem here
because when i need to change the total logic
i must go to CheckoutBasket class

7. GiftMessageCard is responsible for return gift card message to customer
and this function make problem here
because when i need to change message format
i must go to CheckoutBasket class

8. AuthorizePaymentStub is responsible return the authorization message
and this function make problem here
because when i need to change message format
i must go to CheckoutBasket class

## 3. CourseEnrollmentDesk class

1. Register is responsible for register in the course
and this function is good to be here

2. WaitlistPosition responsible for return the index of waiting list
and this function is good to be here

3. WelcomePacketMarkdown is responsible for return the welcome message
and this function make problem here
because when i need to change the message format
i must go to CourseEnrollmentDesk class

4. TuitionInvoiceLine is responsible for return the welcome message
and this function make problem here
because when i need to change the invoice line format
i must go to CourseEnrollmentDesk class

5. PromoteFromWaitlist is responsible for promote wait list
and this function is good to be here


## 4. GradeBook class

1. Record is responsible for assign the student with his score
and this function is good to be here

2. Average is responsible for get average score by student id
and this function is good to be here

3. Letter is responsible for get the average grade by letter by student id
and this function make problem here
because when i need to change the letters
i must go to GradeBook class

4. MeetsHonorRoll is responsible for get the is the student meets the honor roll or not
and this function make problem here
because when i need to change the honor roll policy
i must go to GradeBook class

5. TranscriptPlain is responsible for return the transcript text
and this function make problem here
because when i need to change the transcript text
i must go to GradeBook class

6. ExportCsv is responsible for return the export csv text
and this function make problem here
because when i need to change the export csv text
i must go to GradeBook class

## 5. KitchenTicket class

1. AddItem is responsible for adding items and ingredients to list
and this function is good to be here

2. DetectAllergens is responsible for adding classification to food
and this function make problem here
because when i need to add new classification
i must go to KitchenTicket class

3. EstimatedReadyMinutes is responsible for get the ready minutes
and this function is good to be here

4. RenderThermalTicket is responsible for get the render thermal ticket string
and this function make problem here
because when i need to change render text
i must go to KitchenTicket class

5. ExpoLaneHint is responsible for get the lane hint string
and this function is good to be here

## 6. LoanDesk class

1. RiskScore is responsible for calculate the risk score
and this function is good to be here

2. IsEligible is responsible for to get is it eligible or not
and this function is good to be here

3. RequiredDocuments is responsible for get the requiered docs
and this function make problem here
because when i need to change required documents
i must go to LoanDesk class

4. DecisionLetter is responsible for return decision letter text
and this function make problem here
because when i need to change letter format
i must go to LoanDesk class

5. UnderwriterCsvRow is responsible for write the csv row
and this function make problem here
because when i need to change writer rows
i must go to LoanDesk class

## 7. SubscriptionBilling class

1. Prorate is responsible for calculate prorate by date
and this function make problem here
because when i need to change writer rows
i must go to SubscriptionBilling class

2. NextInvoiceNumber is responsible for get the next invoice number
and this function is good to be here

3. RegisterFailedPayment is responsible for count the failed payment
and this function is good to be here

4. DunningEmail is responsible for get the email text
and this function make problem here
because when i need to change the email format
i must go to SubscriptionBilling class

5. LedgerJournalLine is responsible for get the journal line text
and this function make problem here
because when i need to change the jornal line text
i must go to SubscriptionBilling class

## 8. SupportTicket class

1. AppendCustomerMessage is responsible for adding customer message
and this function is good to be here

2. RecalculatePriorityFromText is responsible for get priority by text
and this function is good to be here

3. SlaDeadline is responsilbe for get the deadline
and this function is good to be here

4. IsBreached is responsilbe for get is it breached or not
and this function is good to be here

5. DraftPublicReply is responsilbe for get reply message
and this function make problem here
because when i need to change the reply text
i must go to SupportTicket class

6. InternalEscalationBlurb is responsible for get the internal escalaction text
and this function make problem here
because when i need to change the internal escalaction text
i must go to SupportTicket class


## 9. WardBoard class

1. AssignBed is responsible for assign patient to bed
and this function is good to be here

2. ScoreAcuity is responsible for calcualte the score by heartrate
and this function make problem here
because when i need to change the score logic
i must go to WardBoard class

3. BuildHandoffNote is responsible for return the handoff text
and this function is good to be here

4. DrainPagerLog is responsible for remove all paper logs and return copy from it
and this function is good to be here

5. ExportCensusCsv is responsible for export the census csv text
and this function make problem here
because when i need to change the census csv text
i must go to WardBoard class

## 10. WarehousePickList class

1. AddNeed is responsible for adding need to line
and this function is good to be here

2. Allocate is responsible for allocation policy
and this function is good to be here

3. WalkingOrder is responsible for change line layout and return it
and this function is good to be here

4. PickerScript is responsible for get the script for handheld devices
and this function make problem here
because when i need to change the script text
i must go to WarehousePickList class

5. WmsXmlBatch is responsible for export the wms xml text
and this function make problem here
because when i need to change the wms xml text
i must go to WarehousePickList class
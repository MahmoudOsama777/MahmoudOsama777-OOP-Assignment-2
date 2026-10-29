using SrpLab;
using SrpLab.NewClasses;

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
Console.WriteLine("=================================================");

var ward = new WardBoard();
ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
Console.WriteLine(ward.BuildHandoffNote(1));
Console.WriteLine(string.Join(" | ", ward.DrainPagerLog()));

var basket = new CheckoutBasket();
basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
Console.WriteLine($"basket total={CheckoutCalculator.GrandTotal(basket.CouponRaw, basket.SubTotal(), basket.GiftWrap)} auth={AuthorizationService.AuthorizePaymentStub("4242", CheckoutCalculator.GrandTotal(basket.CouponRaw, basket.SubTotal(), basket.GiftWrap), basket.Lines.Count)}");
var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);
Console.WriteLine(LetterService.DraftPublicReply("Nora",ticket.Id,ticket.Priority,ticket.SlaDeadline()));

var loan = new LoanDesk(60_000m, 640, 4, hasCollateral: false);
Console.WriteLine(LetterService.DecisionLetter("Omar",loan));

var course = new CourseEnrollmentDesk("SEF-101", capacity: 1, tuition: 3000m);
Console.WriteLine(course.Register("a@mail.com"));
Console.WriteLine(course.Register("b@mail.com"));
Console.WriteLine(WelcomeMarkdownService.WelcomePacketMarkdown("b@mail.com", "Bea", course.CourseCode,course.IsContains("Bea"), course.WaitlistPosition("b@mail.com")));

var kitchen = new KitchenTicket();
kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
Console.WriteLine(RenderThermal.RenderThermalTicket(42, kitchen.EstimatedReadyMinutes(2), kitchen.Ingredients));

var sub = new SubscriptionBilling("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
sub.RegisterFailedPayment();
var amount = FinanceRules.Prorate(sub.PeriodStart,sub.PeriodEnd, new DateOnly(2026, 9, 20),sub.MonthlyPrice);
Console.WriteLine(EmailService.DunningEmail("Sara", new DateOnly(2026, 9, 20), amount, sub.NextInvoiceNumber(), sub.FailedPayments));

var pick = new WarehousePickList();
pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);
Console.WriteLine(DocumentationService.WareHousePickerScript(pick.Allocate(), pick.WalkingOrder(), pick.Lines));

var grades = new GradeBook();
grades.Record("s1", 92);
grades.Record("s1", 88);
var average = grades.Average("s1");
var letter = AcademicPolicy.Letter("s1", average);
var isMeetHonorRoll = AcademicPolicy.MeetsHonorRoll("s1", letter, average);
Console.WriteLine(DocumentationService.TranscriptStudentGrade("s1", "Ali", average, letter, isMeetHonorRoll));

var appt = new AppointmentDesk(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
var slot = appt.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
if (slot is null) throw new InvalidOperationException("no slot");
appt.TryBook(slot.Value);
Console.WriteLine(SmsService.SmsReminder(slot.Value, "0100"));

Console.WriteLine("Done. Now split responsibilities — without breaking behavior.");

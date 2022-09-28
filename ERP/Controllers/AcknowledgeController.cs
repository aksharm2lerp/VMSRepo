using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Entities;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [AllowAnonymous]
    public class AcknowledgeController : Controller
    {
        private IMasterService _masterService { get; set; }
        private IEmailService _emailService { get; set; }
        private IVisitorService _visitorService { get; set; }
        private readonly INotyfService _notyf;

        public AcknowledgeController(IEmailService emailService, INotyfService notyf, IMasterService masterService, IVisitorService visitorService)
        {
            _masterService = masterService;
            _notyf = notyf;
            _emailService = emailService;
            _visitorService = visitorService;
        }

        public ActionResult Feedback(int id)
        {
            var feedbackQuesList = _masterService.GetFeedbackQuestions();
            var model = new VisitorFeedbackMetaData();
            model.feedbackQuestions = feedbackQuesList;
            model.VisitorMeetingRequestID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(VisitorFeedbackMetaData model, IFormCollection collection)
        {
            try
            {
                if (collection.ContainsKey("FeedbackQuestion1"))
                {
                    var model1 = new VisitorFeedbackMetaData();
                    model1.VisitorMeetingRequestID = model.VisitorMeetingRequestID;
                    model1.VisitorFeedbackID = 0;
                    model1.FeedbackQuestionID = 1;
                    model1.Answer = collection["FeedbackQuestion1"];
                    _visitorService.InsertFeedback(model1);
                }
                if (collection.ContainsKey("FeedbackQuestion2"))
                {
                    var model1 = new VisitorFeedbackMetaData();
                    model1.VisitorMeetingRequestID = model.VisitorMeetingRequestID;
                    model1.VisitorFeedbackID = 0;
                    model1.FeedbackQuestionID = 2;
                    model1.Answer = collection["FeedbackQuestion2"];
                    _visitorService.InsertFeedback(model1);
                }
                if (collection.ContainsKey("FeedbackQuestion3"))
                {
                    var model1 = new VisitorFeedbackMetaData();
                    model1.VisitorMeetingRequestID = model.VisitorMeetingRequestID;
                    model1.VisitorFeedbackID = 0;
                    model1.FeedbackQuestionID = 3;
                    model1.Answer = collection["FeedbackQuestion3"];
                    _visitorService.InsertFeedback(model1);
                }
                if (collection.ContainsKey("rating"))
                {
                    var model1 = new VisitorFeedbackMetaData();
                    model1.VisitorMeetingRequestID = model.VisitorMeetingRequestID;
                    model1.VisitorFeedbackID = 0;
                    model1.FeedbackQuestionID = 4;
                    model1.Answer = collection["rating"];
                    _visitorService.InsertFeedback(model1);
                }
                    _notyf.Success("Thank you fo your feedback");
                return RedirectToAction(nameof(Feedback), new { VisitorMeetingRequestID = model.VisitorMeetingRequestID });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

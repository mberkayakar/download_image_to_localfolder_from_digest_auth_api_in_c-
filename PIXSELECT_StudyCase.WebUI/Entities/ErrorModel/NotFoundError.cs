using System;

namespace PIXSELECT_StudyCase.WebUI.Entities.ErrorModel
{
    public class NotFoundError : Exception
    {
        public NotFoundError(string message) :base(message)
        {

        }
    }
}

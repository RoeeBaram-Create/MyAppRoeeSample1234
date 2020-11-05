using FunProject.Domain.Enums;
using System;

namespace FunProject.Application.ActivityLogModule.Dtos
{
    public class ActivityLogDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityDateShortDate => ActivityDate.ToShortDateString();
    }
}
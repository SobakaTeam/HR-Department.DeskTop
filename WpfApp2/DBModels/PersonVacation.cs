﻿using WpfApp2.DBModels.Types;
using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class PersonVacation
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long VacationId { get; set; }

        public virtual Person Person { get; set; } = null;

        public virtual Vacation Vacation { get; set; } = null;

        // Удобные свойства для отображения
        public DateTime StartDate => Vacation != null ? Vacation.BeginDate : DateTime.MinValue;
        public DateTime? EndDate => Vacation != null ? Vacation.EndDate : null;
        public string Type => Vacation != null ? Vacation.VacationType : string.Empty;
        public string Comment => Vacation != null ? $"Отпуск с {Vacation.BeginDate:dd.MM.yyyy}" : string.Empty;
    }
}

﻿using WpfApp2.DBModels.Types;
using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class PersonPosition 
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long PositionId { get; set; }

        public virtual Person Person { get; set; } = null   ;

        public virtual Position Position { get; set; } = null;
    }
}

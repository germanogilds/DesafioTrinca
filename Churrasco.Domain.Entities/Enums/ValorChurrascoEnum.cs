using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Churrasco.Domain.Entities.Enums
{
    public enum ValorChurrascoEnum
    {
        [Description("Sem Bebida")]
        SemBebida = 1,
        [Description("Com Bebida")]
        ComBebida = 2
    }
}

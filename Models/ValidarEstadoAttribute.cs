﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCCRUD.Models
{
    public class ValidarEstado : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strValue = value as string;

            if (!string.IsNullOrEmpty(strValue))
            {
                return new string[]
                {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
                }.Contains(strValue.ToUpper());
            }
            return true;
        }
    }
}
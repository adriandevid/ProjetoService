using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Application.Responses.ApiResponse
{
    public class ApiResponse
    {
        public object? Data { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}

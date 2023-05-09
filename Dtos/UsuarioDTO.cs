using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatingAPI.Enums;

namespace apifinal.Dtos
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Permissions UserType { get; set; }
        
    }
}
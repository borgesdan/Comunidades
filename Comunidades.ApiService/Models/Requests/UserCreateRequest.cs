﻿namespace Comunidades.ApiService.Models.Requests
{
    public class UserCreateRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
    }
}

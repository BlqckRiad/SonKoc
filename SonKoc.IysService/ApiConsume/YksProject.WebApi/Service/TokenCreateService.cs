using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YksProject.BusinessLayer.Abstract;

namespace YksProject.WebApi.Service
{
    public interface ITokenCreateService
    {
        public string CreateTokenforUser();
        public string CreateTokenforAdmin();
        public string CreateTokenforVisitor();
        public string CreateTokenforKurum();
        public string CreateTokenforOgretmen();
        public string CreateTokenWithGenericStructer(string rolAdi);

        public void DeleteMedyaWithUrl (string url);

        public string GetRoleFromToken(string token);
       

    }
    public class TokenCreateService : ITokenCreateService
    {
        private readonly IMedyaKutuphanesiService _medyaKutuphanesiService;
        public TokenCreateService(IMedyaKutuphanesiService medyaKutuphanesiService)
        {
            _medyaKutuphanesiService=medyaKutuphanesiService;
        }
        public string CreateTokenforUser()
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"User"),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string CreateTokenforAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials,claims:claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string CreateTokenforVisitor()
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Visitor"),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string CreateTokenforKurum()
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Kurum"),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string CreateTokenforOgretmen()
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Ogretmen"),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string CreateTokenWithGenericStructer(string rolAdi)
        {
            var bytes = Encoding.UTF8.GetBytes("yks2uygulamamizz");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,rolAdi),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
              notBefore: DateTime.Now, expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public void DeleteMedyaWithUrl(string url)
        {
            var result = _medyaKutuphanesiService.TGetList().FirstOrDefault(x => x.MedyaUrl == url);
            if (result != null)
            {
                result.SilindiMi = true;
                result.SilinmeTarihi = DateTime.Now;
                result.SilenKisiID = 1;

                _medyaKutuphanesiService.TUpdate(result);
            }
        }

        public string GetRoleFromToken(string token)
        {
            
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            // Token içindeki rolleri al
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            return roleClaim;
        }

       
    }


}

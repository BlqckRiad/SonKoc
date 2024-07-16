using System;

namespace SinavService.SinavApi.Service
{
    public interface IHelperFunctions
    {
        public string GenerateRandomKey();
        public int CalculateDifferenceInMinutes(DateTime startTime, DateTime endTime);
        public double CalculateNetScore(int correctAnswers, int wrongAnswers);
    }
    public class HelperFunctions : IHelperFunctions
    {
        public string GenerateRandomKey()
        {
            return Guid.NewGuid().ToString();
        }

        public int CalculateDifferenceInMinutes(DateTime startTime, DateTime endTime)
        {
            return (int)(endTime - startTime).TotalMinutes;
        }

        public double CalculateNetScore(int correctAnswers, int wrongAnswers)
        {
            return correctAnswers - (wrongAnswers / 4.0);
        }
    }
}

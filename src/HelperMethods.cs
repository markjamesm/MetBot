namespace MetBot
{
    public static class HelperMethods
    {
        public static int RandomNumberFromList(List<int> numList)
        {
            var rnd = new Random();
            int rndIndex = rnd.Next(numList.Count);
            int random = numList[rndIndex];

            return random;
        }
    }
}

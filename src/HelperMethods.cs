namespace MetBot
{
    public static class HelperMethods
    {
        public static int RandomNumberFromList(List<int> numList)
        {
            var rnd = new Random();
            int index = rnd.Next(numList.Count);
            int random = numList[index];

            return random;
        }
    }
}

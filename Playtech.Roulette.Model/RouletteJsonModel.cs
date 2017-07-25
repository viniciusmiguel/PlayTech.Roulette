
namespace PlayTech.Model
{
    /*
     * This is the correct input following the JSON specification
     * There's a typo in the job description file
        {
	     "Qualifier":"showWinningNumber",
	     "Correlation":"1",
	     "Data":
	        {
		        "WinningNumber":"22"
	        }
        } 
    */

    public class RouletteJsonModel
    {
        public string Qualifier { get; set; }
        public string Correlation { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string WinningNumber { get; set; }
    }

}

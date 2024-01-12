using MLProject;

namespace MLProject;
internal class Program
{
    static void Main(string[] args)
    {
        // Variable where the users comments will be stored
        var userInput = "";

        // while loop keeps asking for input until user writes "bye"
        while (userInput != "bye")
        {
            // write the following instructive text in console
            Console.WriteLine("                        ************                            ");
            Console.WriteLine("     Hi there! Here you may write what do you think about our restaurant.       ");
            Console.WriteLine("Type \"bye\" if you want to terminate the program");

            //store the user input in the earlier created variable
            userInput = Console.ReadLine();

            //if user input was empty show the following message
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("At least 3 words required for analyse");
                //stay in the wile-loop
                continue;
            }

            //check if user input is not too short. I see that a bit longer comments get a more correct review, so user input has to contain at least 3 words
            if (userInput.Split(' ').Length < 3)
            {
                Console.WriteLine("At least 3 words required for analyse");
                continue;
            }


            //new instance of SentimentModel
            var inputData = new SentimentModel.ModelInput()
            {
                //textual comments used in training are stored in the Col0
                Col0 = userInput
            };

            //predict of the input is positive or negative and store it in the variable
            var prediction = SentimentModel.Predict(inputData);

            // if prediction is 1 - it is positive, if it is 0 - it is negatve
            var result = prediction.PredictedLabel == 1 ? "positive" : "negative";


            //show different texts if result is positive and if it is negative 
            if(result == "positive") {
            Console.WriteLine($"Thanks! Our program thinks that your comment was {result}.");
            }
            else
            {
                Console.WriteLine($"Our program thinks that your comment was {result} :(. We hope next tome your experience will be better!");
            }


        }
    }
}
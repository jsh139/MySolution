using opentoken;

namespace Net5Library
{
    public class Class1
    {
        public string GetUsernameFromSsoOpenToken(string agentConfigFilePath, string openToken)
        {
            var agent = new Agent(agentConfigFilePath);
            var attributes = agent.ReadTokenMultiStringDictionary(token: openToken);
            if (attributes != null)
            {
                return attributes["subject"][0];
            }

            return null;
        }
    }
}

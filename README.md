# ForexConsole
The idea of ForexConsole is to step-by-step refactor an untested application to introduce unit tests. The purpose of ForexConsole is to request foreign exchange price for given currency pairs. A user may asks for quotes for a list of currency pairs (e.g. {"CHFUSD", "USDCHF"}) and retrieves a list of market values including the actual bid/ask prices for each currency pair. Market data is provided by forex.1forge.com.

##### Step 1: Write Unit Tests
- Branch: master
- The project consists of a single project, Forex.Console. It is a simple console application which makes static calls to ForexService in order to retrieve prices for currency pairs.
- There are currently no unit tests available.
- **Tasks:** Write unit tests for ForexService. Create a ForexServiceConfiguration which allows to parameterize ForexService (e.g. ApiKey as configuration parameter). Extract all ForexService related code a seperate assembly so that it can be reused in other applications.

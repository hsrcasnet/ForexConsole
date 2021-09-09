# ForexConsole
The idea of ForexConsole is to step-by-step refactor an untested application to introduce unit tests.
The purpose of ForexConsole is to request FX prices for currency pairs. A user may asks for quotes for a list of currency pairs (e.g. {"CHF_USD", "USD_CHF"}) and retrieves a list of market prices for each currency pair.
The project consists of a single project, Forex.Console. It is a simple console application which makes static calls to ForexService in order to retrieve prices for currency pairs.

##### Step 1: Write unit tests
- There are currently no unit tests available.
- Write unit tests for ForexService.

##### Step 2: Refactor existing code
- Extract all ForexService-related code a seperate assembly so that it can be reused in other applications (e.g. a WPF app).
- Remove static code

##### Step 3: Separated service logic from configuration
- Create a ForexServiceConfiguration which allows to parameterize ForexService (e.g. ApiKey as configuration parameter).
# Digital Cloud Technologies - CryptoTracker WPF

## Technologies
* **.NET 8 / WPF**
* **CommunityToolkit.Mvvm**
* **Microsoft.Extensions**: Hosting, Http, DependencyInjection
* **Newtonsoft.Json**
* **CoinGecko API**

## Feautures
* **Multy-page** navigation.
* **Home page**:
  * Displays the top N currencies by market cup.
  * Search for currency by symbol.
  * Open detailed currency information by double-click.
* **MVVM pattern**, Result pattern, Options pattern.
* **Light/Dark** theme support.
* **Currency converter** on the detailed coin page.

## How to run
1. Locate **appsettings.json** or create **appsettings.Development.json**.
2. Enter your **api key** in the 'CoinGeckoOptions:ApiKey' section.

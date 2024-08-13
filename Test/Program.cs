using OneByMartinDoller.GoogleSheet;
using OneByMartinDoller.Shared;
GoogleSheetsWriter writer = new GoogleSheetsWriter("Test", "C:\\OneByMartinDoller\\OneByMartinDoller.Site\\credentials.json");
await writer.CopySheetsToNewSpreadsheetAsync("1fT-dC4Lg-XhHuqPSMYvoTcXRUZwZYyFZS0cS2NG6DLY", "TestTest");
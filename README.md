# ChatGPT Console App

這段程式碼是使用 C# 語言撰寫的，主要是用來與 Azure AI OpenAI 服務進行互動。程式碼的主要功能是建立一個聊天機器人，並透過 OpenAI 服務來處理和回應用戶的問題。

首先，程式碼在 Main 方法中設定了控制台的輸出編碼為 UTF8，然後輸出一個 "Ready..." 的訊息，表示程式已經準備好運行。

接著，程式碼建立了一個 OpenAIClient 物件，這個物件需要兩個參數：一個是 OpenAI 服務的 URI，另一個是 Azure 的金鑰憑證。這兩個參數分別用來指定 OpenAI 服務的位置和驗證身份。

然後，程式碼建立了一個 ChatCompletionsOptions 物件，並設定了一系列的聊天訊息。這些訊息包括系統、用戶和助理的對話，用來模擬一個真實的對話場景。

之後，程式碼呼叫 GetChatCompletionsStreamingAsync 方法，並傳入模型名稱和聊天選項。這個方法會向 OpenAI 服務發送請求，並獲取聊天的回應。

最後，程式碼使用 foreach 迴圈來遍歷和輸出所有的聊天訊息。每一個訊息都會被輸出到控制台，讓用戶可以看到聊天機器人的回應。

總的來說，這段程式碼是一個簡單的聊天機器人實現，它使用 Azure AI OpenAI 服務來處理和回應用戶的問題。

using System;

// Класс для хранения информации об электронном документе
public class Document {
  public string name { get; set; }
  public string author { get; set; }
  public string[] keywords { get; set; }
  public string theme { get; set; }
  public string filePath { get; set; }
  public virtual string WriteString() {
    return "Document: " + name + " by " + author;
  }
}

// Классы-наследники для документов различных форматов
public class MSWord : Document {
  public override string WriteString() {
    return "MS Word Document: " + name + " by " + author;
  }
}

public class PDF : Document {
  public override string WriteString() {
    return "PDF Document: " + name + " by " + author;
  }
}

public class MSExcel : Document {
  public override string WriteString() {
    return "MS Excel Document: " + name + " by " + author;
  }
}

public class TXT : Document {
  public override string WriteString() {
    return "TXT Document: " + name + " by " + author;
  }
}

public class HTML : Document {
  public override string WriteString() {
    return "HTML Document: " + name + " by " + author;
  }
}

// Singleton класс для управления документами
public class DocumentManager {
  private static DocumentManager instance;
  private DocumentManager() { }
  public static DocumentManager GetInstance() {
    if (instance == null) {
      instance = new DocumentManager();
    }
    return instance;
  }
  public void DisplayDocumentInfo(Document document) {
    Console.WriteLine(document);
    Console.WriteLine("Keywords: " + string.Join(", ", document.keywords));
    Console.WriteLine("Theme: " + document.theme);
    Console.WriteLine("File Path: " + document.filePath);
  }
}

// Консольное приложение
class Program {
  static void Main() {
    DocumentManager documentManager = DocumentManager.GetInstance();

    MSWord msWordDoc = new MSWord {
      name = "Document1",
      author = "Author1",
      keywords = new string[] { "keyword1", "keyword2" },
      theme = "Theme1",
      filePath = "/path/to/document1.docx"
    };
    documentManager.DisplayDocumentInfo(msWordDoc);
  }
}

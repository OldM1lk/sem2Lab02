
using System;

namespace Lab02 {
  class Document {
    public string name;
    public string author;
    public string[] keywords;
    public string theme;
    public string filePath;
    
    public Document(string name, string author, string[] keywords, string theme, string filePath) {
      this.name = name;
      this.author = author;
      this.keywords = keywords;
      this.theme = theme;
      this.filePath = filePath;
    }

    public virtual void GetInfo() {
      Console.WriteLine($"Document name: {name}");
      Console.WriteLine($"Author: {author}");
      Console.WriteLine($"Keywords: {string.Join(", ", keywords)}");
      Console.WriteLine($"Theme: {theme}");
      Console.WriteLine($"File path: {filePath}");
    }
  }

  class MSWord : Document {
    public string front;

    public MSWord(string name, string author, string[] keywords, string theme, string filePath, string front)
                 : base(name, author, keywords, theme, filePath) {
      this.front = front;
    }
    public override void GetInfo() {
      base.GetInfo();
      Console.WriteLine($"Front: {front}");
    }
  }

  class PDF : Document {
    public int pageCount;

    public PDF(string name, string author, string[] keywords, string theme, string filePath, int pageCount)
                 : base(name, author, keywords, theme, filePath) {
      this.pageCount = pageCount;
    }
    public override void GetInfo() {
      base.GetInfo();
      Console.WriteLine($"Page count: {pageCount}");
    }
  }

  class MSExcel : Document {
    public int row, column;

    public MSExcel(string name, string author, string[] keywords, string theme, string filePath, int row, int column)
                 : base(name, author, keywords, theme, filePath) {
      this.row = row;
      this.column = column;
    }
    public override void GetInfo() {
      base.GetInfo();
      Console.WriteLine($"Row count: {row}");
      Console.WriteLine($"Column count : {column}");
    }
  }

  class TXT : Document {
    public int symbolsCount;

    public TXT(string name, string author, string[] keywords, string theme, string filePath, int symbolsCount)
                 : base(name, author, keywords, theme, filePath) {
      this.symbolsCount = symbolsCount;
    }
    public override void GetInfo() {
      base.GetInfo();
      Console.WriteLine($"Symbols count: {symbolsCount}");
    }
  }

  class HTML : Document {
    public string title;

    public HTML(string name, string author, string[] keywords, string theme, string filePath, string title)
                 : base(name, author, keywords, theme, filePath) {
      this.title = title;
    }
    public override void GetInfo() {
      base.GetInfo();
      Console.WriteLine($"Title: {title}");
    }
  }

  class DocumentManager {
    private static DocumentManager instance;
    private DocumentManager() {}
    public static DocumentManager GetInstance() {
      if (instance == null) {
        instance = new DocumentManager();
      }
      return instance;
    }
    public void ShowInfo (Document document) {
      document.GetInfo();
    }
  }

  class Program {
    static void Main(string[] args) {
      DocumentManager manager = DocumentManager.GetInstance();
      bool isProgramRunning = true;
      uint userChoice;

      while (isProgramRunning) {
        Console.WriteLine("О каком документе вывести информацию? (введите цифру от 1 до 5)");
        Console.WriteLine("1. MS Word");
        Console.WriteLine("2. PDF");
        Console.WriteLine("3. MS Excel");
        Console.WriteLine("4. TXT");
        Console.WriteLine("5. HTML");
        Console.WriteLine("0. Выход из программы");
        Console.WriteLine();
        Console.WriteLine("Ваш выбор: ");

        userChoice = Convert.ToUInt16(Console.ReadLine());

        switch (userChoice) {
          case 0:
            isProgramRunning = false;
            break;
          case 1:
            Console.WriteLine();
            Document someWordDocument = new MSWord("My Word Document", "Biba and Boba", new string[] { "word", "document" }, "Programming", "C:/Документы/Word.docx", "Time New Roman");
            manager.ShowInfo(someWordDocument);
            Console.WriteLine();
            break;
          case 2:
            Console.WriteLine();
            Document somePDFDocument = new PDF("My Word Document", "Biba and Boba", new string[] { "word", "document" }, "Programming", "C:/Документы/Word.docx", 67);
            manager.ShowInfo(somePDFDocument);
            Console.WriteLine();
            break;
          case 3:
            Console.WriteLine();
            Document someExcelDocument = new MSExcel("My Word Document", "Biba and Boba", new string[] { "word", "document" }, "Programming", "C:/Документы/Word.docx", 56, 97);
            manager.ShowInfo(someExcelDocument);
            Console.WriteLine();
            break;
          case 4:
            Console.WriteLine();
            Document someTXTDocument = new TXT("My Word Document", "Biba and Boba", new string[] { "word", "document" }, "Programming", "C:/Документы/Word.docx", 3467);
            manager.ShowInfo(someTXTDocument);
            Console.WriteLine();
            break;
          case 5:
            Console.WriteLine();
            Document someHTMLDocument = new HTML("My Word Document", "Biba and Boba", new string[] { "word", "document" }, "Programming", "C:/Документы/Word.docx", "C#");
            manager.ShowInfo(someHTMLDocument);
            Console.WriteLine();
            break;
        }
      }
    }
  }
}

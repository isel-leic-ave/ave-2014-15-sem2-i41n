//
// Code from CLR via C#
//

using System;

// Step #1: Define a type that will hold any additional information that 
// should be sent to receivers of the event notification  
internal class NewMailEventArgs : EventArgs {

	private readonly String m_from, m_to, m_subject;

	public NewMailEventArgs(String from, String to, String subject) {
		m_from = from; m_to = to; m_subject = subject;
	}
		
	public String From    { get { return m_from;    } }
	public String To      { get { return m_to;      } }
	public String Subject { get { return m_subject; } }
}


///////////////////////////////////////////////////////////////////////////////


internal class MailManager {
	// Step #2: Define the event member 
	public event EventHandler<NewMailEventArgs> NewMail;

	// Step #3: Define a method responsible for raising the event 
	// to notify registered objects that the event has occurred
	// If this class is sealed, make this method private and non-virtual
	protected virtual void OnNewMail(NewMailEventArgs e) {
		// If any objects registered interest with our event, notify them 
        if (NewMail != null) NewMail(this, e);
	}

	// Step #4: Define a method that translates the 
	// input into the desired event
   public void SimulateNewMail(String from, String to, String subject) {

      // Construct an object to hold the information we wish
      // to pass to the receivers of our notification
      NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

      // Call our virtual method notifying our object that the event
      // occurred. If no type overrides this method, our object will
      // notify all the objects that registered interest in the event
      OnNewMail(e);
   }
}


///////////////////////////////////////////////////////////////////////////////


internal sealed class Fax {
   // Pass the MailManager object to the constructor
   public Fax(MailManager mm) {

      // Construct an instance of the EventHandler<NewMailEventArgs> 
      // delegate that refers to our FaxMsg callback method.
      // Register our callback with MailManager's NewMail event
		mm.NewMail += FaxMsg;
	}

   // This is the method the MailManager will call
   // when a new e-mail message arrives
   private void FaxMsg(Object sender, NewMailEventArgs e) {

      // 'sender' identifies the MailManager object in case 
      // we want to communicate back to it.

      // 'e' identifies the additional event information 
      // the MailManager wants to give us.

      // Normally, the code here would fax the e-mail message.
      // This test implementation displays the info in the console
      Console.WriteLine("Faxing mail message:");
      Console.WriteLine("   From={0}, To={1}, Subject={2}",
         e.From, e.To, e.Subject);
   }

	// This method could be executed to have the Fax object unregister 
	// itself with the NewMail event so that it no longer receives 
   // notifications
   public void Unregister(MailManager mm) {

      // Unregister ourself with MailManager's NewMail event
      mm.NewMail -= FaxMsg;
   }
}


///////////////////////////////////////////////////////////////////////////////


internal sealed class Pager {
   // Pass the MailManager object to the constructor
   public Pager(MailManager mm) {

      // Construct an instance of the ProcessMailMsgEventHandler 
      // delegate that refers to our SendMsgToPager callback method.
      // Register our callback with MailManager's ProcessMailMsg event
      mm.NewMail += SendMsgToPager;
   }

   // This is the method that the MailManager will call
   // when a new e-mail message arrives
   private void SendMsgToPager(Object sender, NewMailEventArgs e) {

      // 'sender' identifies the MailManager in case 
      // we want to communicate back to it.

      // 'e' identifies the additional event information 
      // that the MailManager wants to give us.

      // Normally, the code here would send the e-mail message to a pager.
      // This test implementation displays the info on the console
      Console.WriteLine("Sending mail message to pager:");
		Console.WriteLine("   From={0}, To={1}, Subject={2}",
			e.From, e.To, e.Subject);
	}

	public void Unregister(MailManager mm) {

		// Construct an instance of the ProcessMailMsgEventHandler 
		// delegate that refers to our FaxMsg callback method.
		//MailManager.ProcessMailMsgEventHandler callback = new MailManager.ProcessMailMsgEventHandler(FaxMsg);

		// Unregister ourself with MailManager's ProcessMailMsg event
		mm.NewMail -= SendMsgToPager;
	}
}


///////////////////////////////////////////////////////////////////////////////


public sealed class Program {
   public static void Main() {
      // Construct a MailManager object
      MailManager mm = new MailManager();

      // Construct a Fax object passing it the MailManager object
      Fax fax = new Fax(mm);

      // Construct a Pager object passing it the MailManager object
      Pager pager = new Pager(mm);

      // Simulate an incoming mail message
      mm.SimulateNewMail("Jeffrey", "Kristin", "I Love You!");

      // Force the Fax object to unregister itself with the MailManager
      fax.Unregister(mm);

      // Simulate an incoming mail message
      mm.SimulateNewMail("Jeffrey", "Mom & Dad", "Happy Birthday.");
   }
}


//////////////////////////////// End of File //////////////////////////////////

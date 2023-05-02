using UnityEngine;

public class EightiesClubDialogueScript : MonoBehaviour
{
	public SubtitleScript Subtitle;

	public void UpdateDialogue(int ClubID)
	{
		switch (ClubID)
		{
		case 2:
			Subtitle.ClubGreetings[ClubID] = "Oh my, you must be a fan! Sorry, I'm not signing autographs right now...";
			Subtitle.Club2Info[1] = "We are Akademi's Drama Club - rising stars, the next generation of talent, the future of the entertainment industry!";
			Subtitle.Club2Info[2] = "You are welcome to join us, if you'd like to! Come on, don't you want to be able to say that you knew us before we were famous?";
			Subtitle.Club2Info[3] = "Plus, if you join our club, you'll get access to our equipment! Just don't do anything naughty while wearing our masks and gloves!";
			Subtitle.ClubUnwelcomes[ClubID] = "You can't just put on a performance and expect me to forget what you did! You MURDERED someone. I SAW it. Now, leave!";
			Subtitle.ClubKicks[ClubID] = "One of my crewmates wants you gone, so I'm going to have to cut you from our crew. Sorry, kid...that's showbiz.";
			Subtitle.ClubJoins[ClubID] = "So, you wish to join our exclusive entourage?";
			Subtitle.ClubAccepts[ClubID] = "Normally, I'd make you audition for the role...but I can already see your star quality! You've got the part!";
			Subtitle.ClubRefuses[ClubID] = "Ah, tsk tsk. Well, I understand...not everyone is cut out to be a celebrity, after all.";
			Subtitle.ClubRejoins[ClubID] = "I already gave you a shot at stardom, and you blew it. You left our crew, and THE SHOW MUST GO ON...without you.";
			Subtitle.ClubExclusives[ClubID] = "If you want to prove that you're ready to commit to the performing arts, you'll have to drop your current club.";
			Subtitle.ClubGrudges[ClubID] = "Sorry, I can't let you join us. One of my crewmates...isn't your biggest fan. Please leave before you cause a scandal!";
			Subtitle.ClubQuits[ClubID] = "What's this? You wish to leave our crew?";
			Subtitle.ClubConfirms[ClubID] = "How unprofessional of you! I didn't even have enough time to prepare an understudy...";
			Subtitle.ClubDenies[ClubID] = "Good decision! The road to stardom is tough, but it'll all be worth it!";
			Subtitle.ClubFarewells[ClubID] = "Remember my name, kid!";
			Subtitle.ClubActivities[ClubID] = "You're needed on set! Please, get into position!";
			Subtitle.ClubEarlies[ClubID] = "We'll be rehearsing between 5:00 and 5:30. I hope to see you on set!";
			Subtitle.ClubLates[ClubID] = "Sorry, kid. Your call time was between 5:00 and 5:30, and you've missed it.";
			Subtitle.ClubYeses[ClubID] = "Three...two...one...aaaaand, ACTION!";
			Subtitle.ClubNoes[ClubID] = "My, what a diva. Fine, I'll pause production, but only until 5:30.";
			break;
		case 3:
			Subtitle.ClubGreetings[ClubID] = "...uh...is there...something wrong...?...";
			Subtitle.Club3Info[1] = "We are the Occult Club. We study the supernatural...with a particular emphasis on black magic and demons.";
			Subtitle.Club3Info[2] = "Please, don't get the wrong idea...we don't wish harm on anyone, we're just fascinated by anything...otherworldly.";
			Subtitle.Club3Info[3] = "If you join our club, you'll grow a tolerance for...horrific things. In short...you'll develop a stronger grip on your sanity.";
			Subtitle.ClubUnwelcomes[ClubID] = "You! Do you think that just because I enjoy the Occult, I would condone murder?! Begone...or I'll cast a hex on you!";
			Subtitle.ClubKicks[ClubID] = "I apologize, but...your dark aura is interfering with our rituals. You simply...can't be in this club anymore.";
			Subtitle.ClubJoins[ClubID] = "Wait...what? You...really want to join us? You're...not pulling a prank on me, are you?";
			Subtitle.ClubAccepts[ClubID] = "Oh, joyous day! Thank you...for being open minded.";
			Subtitle.ClubRefuses[ClubID] = "Oh. Yes...I should have known. Run along, now...before someone sees you talking to us ''freaks''...";
			Subtitle.ClubRejoins[ClubID] = "Honestly...it hurt when you left us. We couldn't bear to go through that again. So, no...you can't come back.";
			Subtitle.ClubExclusives[ClubID] = "I can tell that you're just pretending to be interested in joining our club; you're already a member of another club.";
			Subtitle.ClubGrudges[ClubID] = "One of my clubmembers is certain that you are possessed by a demon. For our safety...I can't let you join our club..";
			Subtitle.ClubQuits[ClubID] = "Oh, no...don't tell me you're...quitting...?";
			Subtitle.ClubConfirms[ClubID] = "Ugh...I should have known...I thought you would be different, but...no...in the end...you're just like everyone else.";
			Subtitle.ClubDenies[ClubID] = "Phew...that's a relief. You really had me worried there!";
			Subtitle.ClubFarewells[ClubID] = "...uh...goodbye...I guess...";
			Subtitle.ClubActivities[ClubID] = "The stars have aligned. The time is right for a ritual. You will be joining us, yes?";
			Subtitle.ClubEarlies[ClubID] = "The door to the spirit realm will open between 5:00 and 5:30. Please join us then for a ritual.";
			Subtitle.ClubLates[ClubID] = "Sorry, you're too late. The door to the spirit realm closed at 5:30. ...I hope that you didn't skip the ritual on purpose...";
			Subtitle.ClubYeses[ClubID] = "Excellent! Let us begin the incantation...";
			Subtitle.ClubNoes[ClubID] = "Please hurry...we can't begin the ritual after 5:30.";
			break;
		case 4:
			Subtitle.ClubGreetings[ClubID] = "A friend! Bienvenue!";
			Subtitle.Club4Info[1] = "We are the Art Club of Akademi! We specialize in all forms of visual artistry. Painting, drawing, sculpting, and crafting, to name a few!";
			Subtitle.Club4Info[2] = "As an experienced artiste, I'd be happy to make you my protege. Before you know it, you'll be creating your very own masterpieces!";
			Subtitle.Club4Info[3] = "If you intend to get messy, wear one of our smocks! Then nobody will bat an eyelash at anything you've spilled on yourself! C'est bon!";
			Subtitle.ClubUnwelcomes[ClubID] = "You think you can come in here and put on an innocent facade? Au contraire! I saw what you did, now get out of my sight!";
			Subtitle.ClubKicks[ClubID] = "I'm sorry, but I don't think you're a good fit for our club. You're going to have to leave. Hasta la vista!";
			Subtitle.ClubJoins[ClubID] = "Would you like to join moi and my fellow artistes?";
			Subtitle.ClubAccepts[ClubID] = "C'est magnifique! Welcome to the art club!";
			Subtitle.ClubRefuses[ClubID] = "In that case, please leave me to tend to mon art.";
			Subtitle.ClubRejoins[ClubID] = "Well, well - I seem to have a case of deja vu! Sorry, but I can't let you rejoin the club after you've already quit once before.";
			Subtitle.ClubExclusives[ClubID] = "Non; you're already in a club. If you want to join us, you'll have to quit your current club.";
			Subtitle.ClubGrudges[ClubID] = "I'm sorry, but it seems you've made a faux pas in front of one of my members, it's best you don't join the club.";
			Subtitle.ClubQuits[ClubID] = "Pardon, but are you really considering leaving the club?";
			Subtitle.ClubConfirms[ClubID] = "What a shame...oh, well. C'est la vie!";
			Subtitle.ClubDenies[ClubID] = "Oui, I'm happy to hear that!";
			Subtitle.ClubFarewells[ClubID] = "Au revoir!";
			Subtitle.ClubActivities[ClubID] = "Shall we begin our club rendezvous?";
			Subtitle.ClubEarlies[ClubID] = "I'm glad that you feel inspired! But, it's not time for our club activity yet. We will create artwork en masse from 5:00 to 5:30.";
			Subtitle.ClubLates[ClubID] = "Non, it's too late to join. We've already washed our brushes! Next time, make sure you're here between 5:00 and 5:30.";
			Subtitle.ClubYeses[ClubID] = "Bien, bien! Let's begin!";
			Subtitle.ClubNoes[ClubID] = "Take your time to find your muse, mon cheri. But, we can't wait past 5:30.";
			break;
		}
	}
}

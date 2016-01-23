var checkTest = function () {
	
//	var balls = 0; //балл за вопрос

	var testBoxOne = 0;
	var testBoxTwo = 0;
	var testradio = 0;
	var correctAnswers = 0;
	var correctAnswersPercent = 0;
	var s = $("input");
	
		s.each(function(i, elem){
		if($("input:radio").eq(i).prop("checked") == true) {
			if(i==0 || i==6 || i==11){
				testradio = testradio + 1;                 
			}                   
		}
		
		if ($("input.table").eq(i).prop("checked") == true){
			if(i==1 || i==3){
				testBoxOne = testBoxOne+0.5;
			}else {
				testBoxOne = testBoxOne-0.5;
			}
		}
			
		if ($("input.formBox").eq(i).prop("checked") == true){
			if(i==0 || i==1){
				testBoxTwo = testBoxTwo+0.5;
			}else {
				testBoxTwo = testBoxTwo-0.5;
			}
		}		
		
	})
	correctAnswers = testradio + Math.max(testBoxOne,0) + Math.max(testBoxTwo,0);
	correctAnswersPercent = (correctAnswers / 5) * 100;
	
		
		switch (true){
			case correctAnswersPercent < 25:
				alert("Aargh! You are not ready! Your mark: " + correctAnswers + " points, " + "this is: " + correctAnswersPercent + "% of the maximum");
				break;
			case correctAnswersPercent < 50:
				alert("Aargh! Bad! Bad result!. Your mark: " + correctAnswers + " points, " + "this is: " + correctAnswersPercent + "% of the maximum");
				break;
			case correctAnswersPercent < 75:
				alert("Aargh! Bad result!! Your mark: " + correctAnswers + " points, " + "this is: " + correctAnswersPercent + "% of the maximum");
				break;
			case correctAnswersPercent < 100:
				alert("Aargh! Good result! Your mark: " + correctAnswers + " points, " + "this is: " + correctAnswersPercent + "% of the maximum");
				break;
			case correctAnswersPercent == 100:
				alert("Aargh! Great, wonderful, incredibly good result! Your mark: " + correctAnswers + " points, " + "this is: " + correctAnswersPercent + "% which is the maximum number of correct answers!");
				break;
			 default:
			 alert("Aargh! I don't know what are you want!");
		}
	}
	
	$("#butResult").click(checkTest);

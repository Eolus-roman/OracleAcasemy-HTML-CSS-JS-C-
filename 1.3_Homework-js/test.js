function checkTest() {
	var d=document;
	var balls = 0; //балл за вопрос
	var correctAnswers = 0; //Кол-во правильных ответов
	var totalQuestions = 5; //Всего вопросов

	
	var i = 0;
		for(i; i<d.getElementsByName("link").length; i++){
		if(d.getElementsByName("link")[i].checked) {    
			if(i==0){
				balls+=2; correctAnswers++;
				} else {
					correctAnswers = correctAnswers - 1; balls = balls-2;
				}
			}
		}
		
	var i=0;
		for(i; i<d.getElementsByName("list").length; i++){
		if(d.getElementsByName("list")[i].checked) {    
			if(i==2){
				balls+=2; correctAnswers++;
				} else {
					correctAnswers = correctAnswers - 1; balls = balls-2;
				} //radio, Какой тег предназначен для создания нумерованного списка: <ol> 
			}
		}
		
	var i = 0;
		for(i; i<d.getElementsByName("transfer").length; i++){
		if(d.getElementsByName("transfer")[i].checked) {    
			if(i==3){
				balls+=2; correctAnswers++;
				}  else {
					correctAnswers = correctAnswers - 1; balls = balls-2;
				}    //radio, Какой тег предназначен для передачи служебной информации браузеру: <meta /> 
			}
		}
		
	var i = 0;
	for(i=0; i<d.getElementsByName("table").length; i++){
		if(d.getElementsByName("table")[i].checked) {
			if(i==0) {
				balls = balls -1; correctAnswers = correctAnswers - 0.5;
			}
			if(i==1) {
				balls+=1; correctAnswers+=0.5;
			}  
			if(i==2) {
				balls = balls -1; correctAnswers = correctAnswers - 0.5;
			}
			if(i==3) {
				balls+=1; correctAnswers+=0.5;
			}  
			
		}
	  
    }
	
	var i = 0;
	for(i=0; i<d.getElementsByName("formBox").length; i++){
		if(d.getElementsByName("formBox")[i].checked) {
		
			if(i==0) {
				balls+=1; correctAnswers+=0.5;
			}  
			if(i==1) {
				balls+=1; correctAnswers+=0.5;
			} 
			if(i==2) {
				balls = balls -1; correctAnswers = correctAnswers - 0.5;
			}
			if(i==3) {
				balls = balls -1; correctAnswers = correctAnswers - 0.5;
			}
	  
		}
	}

	
	alert("Максимум за тест 10 баллов. Вы набрали: "+balls+ " баллов. Процент верных ответов составил: "+(correctAnswers / totalQuestions)*100 +"%."); 
}
var elem = document.getElementById("butResult");
elem.onclick = checkTest;
var memory = "0" // Память
var current = "0" // Дисплей, текущее значение
var operation = 0 // операции, такие как деление, умножение и т.д.
var MAXLENGTH = 30
var podium = $("#dis"); //document.getElementById('dis');



function addDigit(dig) {         //ADD A DIGIT TO DISPLAY (keep as 'current')
	if (podium.val().indexOf("!") == -1) {   //if not already an error
		if ( (eval(podium.val()) == 0)&& (podium.val().indexOf(".") == -1) ) { 
			podium.val(dig);
		} else { 
			podium.val(podium.val()+dig)
		}
	} else { 
		podium.val("Hint! Press 'C'");  //Help out, if error present.
	}
	if (podium.val().indexOf("e0") != -1) {
		var epos = podium.val().indexOf("e");
		podium.val(podium.val().substring(0,epos+1) + podium.val().substring(epos+2));
    }
	if (podium.val().length > MAXLENGTH) { 
		podium.val("Aargh! Too long") ; //don't allow over MAXLENGTH digits before "." ???
	}
			
			
}
//podium.val()
var dot = function () {                 //PUT IN "." if appropriate.
	if ( podium.val().length == 0) {     //no leading ".", use "0."
		podium.val("0.");
    } else {
		if (( podium.val().indexOf(".") == -1)&&( podium.val().indexOf("e") == -1)) { 
		podium.val(podium.val() + ".") ;
		} 
	}

}
var plusMinus = function () {
	podium.val(podium.val() * -1);
 }

var clearAll = function () { //Clear ALL entries!
	podium.val("0");
	operation = 0;                //clear operation
	memory = "0";                  //clear memory

}
function operate(op) {            //STORE OPERATION e.g. + * / etc.
/*	if (operation != 0) { 
		calculate(); 
	}*/
	if (op.indexOf("*") > -1) {
		operation = 1; 
		} 
	if (op.indexOf("/") > -1) {
		operation = 2; 
		} 
	if (op.indexOf("+") > -1) {
		operation = 3; 
		}
	if (op.indexOf("-") > -1) { 
		operation = 4; 
		}
	memory = podium.val();
	//current = "";
	podium.val("");
    
}

function fixCurrent() {
	
	podium.val() = "" + parseFloat(podium.val());
	if (podium.val().indexOf("NaN") != -1) {
		podium.val("Aargh! I don't understand");
    }
    
}

var calculate = function () { //PERFORM CALCULATION (= button)
	if (operation == 1) {
		podium.val( eval(memory) * eval(podium.val())); 
	}
	if (operation == 2) { 
		if (eval(podium.val()) != 0) { 
			podium.val( eval(memory) / eval(current));
		} else  {
			podium.val( "Aargh! Divide by zero"); 
		}
    }
	if (operation == 3) {
		current = eval(memory) + eval(current); 
	}
	if (operation == 4) { 
		current = eval(memory) - eval(current); 
	}
	operation = 0;                
	memory = "0";                  
	current = current + "";       
	if (current.indexOf("Infinity") != -1) {
		current = "Aargh! Value too big";
    }
	if (current.indexOf("NaN") != -1) {
		current = "Aargh! I don't understand";
    }
    podium.val(current);
	// NOTE: if no operation, nothing changes, current is left the same!
}

$("#plusmin").click(plusMinus);
$("#design").click(calculate);
$("#dotID").click(dot);
$("#clear").click(clearAll);
$("#dis").change(fixCurrent);



$(function() {
	$("#number").click(function() {
		addDigit($(this).val());
	});
});

$(function() {
	$("#functional").click(function() {
		operate($(this).val());
	});
});

//document.getElementById("dis").onChange = fixCurrent;



/*
document.getElementById("zero").onclick = function(){addDigit('0');}
document.getElementById("one").onclick = function(){addDigit('1');}
document.getElementById("two").onclick = function(){addDigit('2');}
document.getElementById("three").onclick = function(){addDigit('3');}
document.getElementById("four").onclick = function(){addDigit('4');}
document.getElementById("five").onclick = function(){addDigit('5');}
document.getElementById("six").onclick = function(){addDigit('6');}
document.getElementById("seven").onclick = function(){addDigit('7');}
document.getElementById("eight").onclick = function(){addDigit('8');}
document.getElementById("nine").onclick = function(){addDigit('9');}
document.getElementById("plusmin").onclick = plusMinus; //+-
document.getElementById("multiplication").onclick = function(){operate('*');}
document.getElementById("divide").onclick = function(){operate('/');}
document.getElementById("minus").onclick = function(){operate('-');}
document.getElementById("plus").onclick = function(){operate('+');}
document.getElementById("design").onclick = calculate; // =
document.getElementById("dotID").onclick = dot; // .
document.getElementById("clear").onclick = clearAll; // C
*/
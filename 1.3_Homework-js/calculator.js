var memory = "0" // Память
var current = "0" // Дисплей, текущее значение
var operation = 0 // операции, такие как деление, умножение и т.д.
var MAXLENGTH = 30
var podium = document.getElementById('dis');



function addDigit(dig) {         //ADD A DIGIT TO DISPLAY (keep as 'current')
	if (current.indexOf("!") == -1) {   //if not already an error
		if ( (eval(current) == 0)&& (current.indexOf(".") == -1) ) { 
			current = dig;
		} else { 
			current = current + dig;
		}
	} else { 
		current = "Hint! Press 'C'";  //Help out, if error present.
	}
	if (current.indexOf("e0") != -1) {
		var epos = current.indexOf("e");
		current = current.substring(0,epos+1) + current.substring(epos+2);
    }
	if (current.length > MAXLENGTH) { 
		current = "Aargh! Too long"; //don't allow over MAXLENGTH digits before "." ???
	}
	podium.value = current;
}

function dot() {                 //PUT IN "." if appropriate.
	if ( current.length == 0) {     //no leading ".", use "0."
		current = "0.";
    } else {
		if (( current.indexOf(".") == -1)&&( current.indexOf("e") == -1)) { 
		current = current + ".";
		} 
	}
    podium.value = current;
}
function plusMinus() {
	if  (current.indexOf("e") != -1) { 
		var epos = current.indexOf("e-");
		if (epos != -1) {
			current = current.substring(0,1+epos) + current.substring(2+epos); //clip out -ve exponent 
        }	else {
			epos = current.indexOf("e");
			current = current.substring(0,1+epos) + "-" + current.substring(1+epos); //insert -ve exponent
			}
		} else { 
			if (current.indexOf("-") == 0) {
				current = current.substring(1);
			} else { 
			current = "-" + current;
			}
		if ((eval(current) == 0)&& (current.indexOf(".") == -1 )) {
			current = "0"; 
		}
    }
    podium.value = current;
 }

function clearAll() { //Clear ALL entries!
	current = "0";
	operation = 0;                //clear operation
	memory = "0";                  //clear memory
    podium.value = current;
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
	memory = current;
	current = "";
    podium.value = current;
}

function fixCurrent() {
	current = podium.value;
	current = "" + parseFloat(current);
	if (current.indexOf("NaN") != -1) {
		current = "Aargh! I don't understand";
    }
    podium.value = current;
}

function calculate() { //PERFORM CALCULATION (= button)
	if (operation == 1) {
		current = eval(memory) * eval(current); 
	}
	if (operation == 2) { 
		if (eval(current) != 0) { 
			current = eval(memory) / eval(current);
		} else  {
			current = "Aargh! Divide by zero"; 
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
    podium.value = current;
	// NOTE: if no operation, nothing changes, current is left the same!
}

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
document.getElementById("dis").onChange = fixCurrent;
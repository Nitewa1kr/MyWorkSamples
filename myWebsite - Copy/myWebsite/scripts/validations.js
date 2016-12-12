var name;
var area,three,four;
var email;

function user_isValid()
{
	name = document.form1.user.value;

	var name_chk = /^[a-zA-Z ]+$/

		if(name_chk.test(name))
		{
			return true;
			document.form1.area.focus();
		}
		else
		{
			alert("INVALID USER NAME");
			document.form1.user.value = "";
			document.form1.user.focus();
			return false;
		}
		
}
function area_isValid(area)
{
    var area = /^[1-9]{1}[0-9]{9}$/;
	//phone_num.area = phone_num.area.replace(/[^0-9]/g, '');
	//AREA CODE
    area = document.form1.area.value;
    
	if(document.form1.area.value == false)
	{
			if(area.length <=3)
			{
			    document.form1.three.focus();
			}
			else
			{
			    document.form1.area.focus();
			}
	}
}
function three_isValid()
{//FIRST THREE DIGITS
	three = document.form1.three.value;
	three = parseInt(three);
	if(!isNaN(three) && three != null && three != 0)
	{
		if(three.length <=3)
		{
			document.form1.three.focus();
		}
		else
		{
			document.form1.four.focus();
		}
	}
}

function four_isValid()
{//NEXT FOUR DIGITS
	four = document.form1.four.value;
	four = parseInt(four);
	if(!isNaN(four) && four != null && four != 0)
	{
		if(four.length <=3)
		{
			document.form1.four.focus();
		}
		else
		{
			document.form1.email.focus();
		}
	}
}
function email_isValid()
{
	email = document.form1.email.value;
	var filter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
	if(filter.test(email))
	{
		return true;
		document.form1.myBtn.focus();
	}
	else
	{
		alert("INVALID EMAIL");
		document.form1.email.value = "";
		document.form1.email.focus();
		return false;
	}
	/*var position_at = email.indexOf("@");
	var position_dot = email.lastIndexOf(".");

	if(position_at < 1 || position_dot+2 || position_dot+2>= email.length)
	{
		alert("INVALID EMAIL");
		document.form1["email"].value = "";
		document.form1["email"].focus();
		return false;
	}*/
}

function display()
{

    alert("This user has been validated");
}
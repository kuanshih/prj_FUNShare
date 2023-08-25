const date = new Date();



const renderCalendar=()=>{


    date.setDate(1);

    const monthDays =document.querySelector(".days");

    
    const lastDay = new Date(date.getFullYear(),date.getMonth()+1,0).getDate()
    
    const prevLastDay = new Date(date.getFullYear(),date.getMonth(),0).getDate()
    
    
    
    const firstDayIndex = date.getDay(); 
    
    const lastDayIndex = new Date(date.getFullYear(),date.getMonth()+1,0).getDay()
    
    console.log(lastDayIndex)
    const nextDays = 7-lastDayIndex-1;
    
    const months=[
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December",
    ];
    document.querySelector(".date h1").innerHTML = months[date.getMonth()];
    
    document.querySelector('.date p').innerHTML =new Date().toDateString();
    
    let days ="";
    
    const t = new Date(date.getFullYear()+date.getMonth()+1)
    console.log(t)

    for(let x=firstDayIndex;x>0;x--){
        let pick = date.getFullYear()+'-'+(date.getMonth().toString().padStart(2, '0'))+'-'+(prevLastDay-x+1);
        days+=`<div class="prev-date flip" data-id="${pick}">${prevLastDay-x+1}</div>`
        
    }
    for(let i =1; i<=lastDay;i++){
        if(i===new Date().getDate()&&date.getMonth()===new Date().getMonth()){
            let pick = date.getFullYear()+'-'+(date.getMonth()+1).toString().padStart(2, '0')+'-'+i;
            days+=`<div class="today flip" data-id="${pick}">${i}</div>`;
        }
        else{
            let pick = date.getFullYear()+'-'+(date.getMonth()+1).toString().padStart(2, '0')+'-'+i;
            days+=`<div class="flip" data-id="${pick}">${i}</div>`;
        }
    }
    
    for(let j=1;j<=nextDays;j++){
        let pick = date.getFullYear()+'-'+(date.getMonth()+2).toString().padStart(2, '0')+'-'+j;
        days+=`<div class="next-date flip" data-id="${pick}">${j}</div>`
        
    }
monthDays.innerHTML =days;

      
}



    document.querySelector('.prev').addEventListener('click', () => {
        date.setMonth(date.getMonth() - 1);
        renderCalendar();
        flip();
    });

    document.querySelector('.next').addEventListener('click', () => {
        date.setMonth(date.getMonth() +1);
        console.log(this)
        renderCalendar();
        flip();
    });

   

  renderCalendar();
  flip();

//收合script
let x =0;
let clicked =false;
        function flip(){$('.flip').click(function() {
            if(!clicked){
                    console.log(this)
                    $(".schedule").slideToggle("slow");
                    x = $(this).data().id
                    console.log(x)
                    $(".schedule h1").html(x+' schedule')
                    
                        $('#list').empty()
                        $('#list').append(`<li>${x}</li>`)
                
            clicked=true
            }
            else{
                if($(this).data().id===x){
                    $(".schedule").slideToggle("slow");
                   
                    clicked = false;
                }
                else{
                    x = $(this).data().id
                       $('#list').empty()
                       $(".schedule h1").html(x+' schedule')
                        $('#list').append(`<li>${x}</li>`)
                        clicked = true;
                }
            } 
        })};
      
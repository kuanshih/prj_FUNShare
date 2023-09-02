const date = new Date();
let getDate;


async function renderCalendar(){
    const value = await schedule();
    const getData = value;
    console.log(getData);
    
    date.setDate(1);

    const monthDays = document.querySelector(".days");


    const lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate()

    const prevLastDay = new Date(date.getFullYear(), date.getMonth(), 0).getDate()



    const firstDayIndex = date.getDay();

    const lastDayIndex = new Date(date.getFullYear(), date.getMonth() + 1, 0).getDay()

    // console.log(lastDayIndex)
    const nextDays = 7 - lastDayIndex - 1;

    

    const months = [
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

    document.querySelector('.date p').innerHTML = new Date().toDateString();

    let days = "";
    
    

    for (let x = firstDayIndex; x > 0; x--) {
        let pick = date.getFullYear() + '-' + (date.getMonth().toString().padStart(2, '0')) + '-' + (prevLastDay - x + 1);
        // days += `<div class="prev-date flip" data-id="${pick} id="${pick}">${prevLastDay - x + 1}</div>`
        let pickNew = new Date(pick);
        let t = 0;
        for (let i = 0; i < getData.length; i++) {
            let beginTime = new Date(getData[i].beginTime);
            let endTime = new Date(getData[i].endTime);
            console.log(pickNew)
            if (beginTime.getFullYear() == pickNew.getFullYear() && beginTime.getMonth() == pickNew.getMonth() && beginTime.getDate() == pickNew.getDate()) {
                console.log(beginTime.getFullYear())
                t = 1;
                break
            }
            else {
                t = 0;
            }
        }

        if (t == 1) {
            days += `<div class="prev-date flip" data-id="${pick}" id="${pick}" style="color: white,
                                       ;background-color: #73BF00">${prevLastDay - x + 1}</div>`
        }
        else {
            days += `<div class="prev-date flip" data-id="${pick}" id="${pick}">${prevLastDay - x + 1}</div>`
        }
    }

    let t = 0;
    for (let i = 1; i <= lastDay; i++) {
        if (i === new Date().getDate() && date.getMonth() === new Date().getMonth()) {
            let pick = date.getFullYear() + '-' + (date.getMonth() + 1).toString().padStart(2, '0') + '-' + i;
            let pickNew = new Date(pick);
            let t = 0;
            for (let i = 0; i < getData.length; i++) {
                let beginTime = new Date(getData[i].beginTime);
                let endTime = new Date(getData[i].endTime);
                console.log(pickNew)
                if (beginTime.getFullYear() == pickNew.getFullYear() && beginTime.getMonth() == pickNew.getMonth() && beginTime.getDate() == pickNew.getDate()) {
                    console.log(beginTime.getFullYear())
                    t = 1;
                    break
                }
                else {
                    t = 0;
                }
            }

            if (t == 1) {
                days += `<div class="today flip" data-id="${pick}" id="${pick}"  style="color: white,
                           ;background-color: #73BF00">${i}</div>`;
            }
            else {
                days += `<div class="today flip" data-id="${pick}" id="${pick}">${i}</div>`;
            }

        }
        else {
            let pick = date.getFullYear() + '-' + (date.getMonth() + 1).toString().padStart(2, '0') + '-' + i;
            
            let pickNew = new Date(pick);
            let t = 0;
            for (let i = 0; i < getData.length; i++) {
                let beginTime = new Date(getData[i].beginTime);
                let endTime = new Date(getData[i].endTime);
                console.log(pickNew)
                if (beginTime.getFullYear() == pickNew.getFullYear() && beginTime.getMonth() == pickNew.getMonth() && beginTime.getDate() == pickNew.getDate()) {
                    console.log(beginTime.getFullYear())
                    t = 1;
                    break
                }  
                else{
                    t = 0;
                }
            }
            
            if (t == 1) {
                days += `<div class="flip" data-id="${pick}" id="${pick}" style="color: white,
               ;background-color: #73BF00">${i}</div>`;
            }
            else {
                days += `<div class="flip" data-id="${pick}" id="${pick}">${i}</div>`;
            }
        }
    }

    for (let j = 1; j <= nextDays; j++) {
        let pick = date.getFullYear() + '-' + (date.getMonth() + 2).toString().padStart(2, '0') + '-' + j;
        let pickNew = new Date(pick);
        let t = 0;
        for (let i = 0; i < getData.length; i++) {
            let beginTime = new Date(getData[i].beginTime);
            let endTime = new Date(getData[i].endTime);
            console.log(pickNew)
            if (beginTime.getFullYear() == pickNew.getFullYear() && beginTime.getMonth() == pickNew.getMonth() && beginTime.getDate() == pickNew.getDate()) {
                console.log(beginTime.getFullYear())
                t = 1;
                break
            }
            else {
                t = 0;
            }
        }

        if (t == 1) {
            days += `<div class="next-date flip" data-id="${pick}" id="${pick}"  style="color: white,
                           ;background-color: #73BF00">${j}!!!</div>`
        }
        else {
            days += `<div class="next-date flip" data-id="${pick}" id="${pick}">${j}</div>`
        }

    }
    monthDays.innerHTML = days;
    await flip();
}

document.querySelector('.prev').addEventListener('click', () => {
    date.setMonth(date.getMonth() - 1);
    renderCalendar();

});

document.querySelector('.next').addEventListener('click', () => {
    date.setMonth(date.getMonth() + 1);
    console.log(this)
    renderCalendar();
 
});

renderCalendar();
// 產生選單選項的函式
/**
 * 
 * @param {number} min 
 * @param {number} max 
 * @param {number} now 
 * @returns string
 */
function makeOptions(min, max, now) {
    let options = '';
    for (let i = min; i < (max + 1); i++) {
        // 新增參數now，用來判斷目前的年/月，設成選單預設值
        if (i == now) {
            options += `<option value="${i}" selected>${i}</option>`;
        }
        else {
            options += `<option value="${i}">${i}</option>`;
        }
    }
    return options;
}

// 加入至下拉式選單
$('#yy').html(makeOptions(1950, 2050, new Date().getFullYear()));
$("#mm").html(makeOptions(1, 12, (new Date().getMonth() + 1)));

// 定義目前選取的年月(一定要用數字類型，代表要呈現的年與月)
let year = Number($('#yy').val());
let month = Number($('#mm').val());

// 今天的年月日
const todayfullDate = `${new Date().getFullYear()}/${new Date().getMonth() + 1}/${new Date().getDate()}`;
// 呈現
$("#today").text(`今天：${todayfullDate}`);

// 分割陣列的函式
function chunk(arr, size) {
    let myArray = [];
    for (let i = 0; i < arr.length; i += size) {
        myArray.push(arr.slice(i, i + size));
    }
    return myArray;
}

// 產生月曆的函式
/**
 * 
 * @param {number} year 
 * @param {number} month
 */
function genrateClander(year, month) {
    // 當月第一天是星期幾
    const firstDay = new Date(year, month - 1, 1).getDay();
    // 當月有幾天
    const days = new Date(year, month, 0).getDate();

    //------ 以下開始產生資料陣列
    // 最前面塞入空白字串的陣列
    const emptyData = Array(firstDay).fill('');

    // 有值的陣列1 ~ days
    // 如何建立一個陣列包含1...N數字
    // https://stackoverflow.com/questions/3746725/how-to-create-an-array-containing-1-n
    const valueData = Array(days).fill('').map((v, i) => i + 1);

    // 合併兩陣列為一長陣列，並先加入<td>xxxx</td>標記
    // 同時加上判斷(是否為今天、是否有值)，套入對應的樣式類別
    const allData = [...emptyData, ...valueData].map((v) => {
        if (year === new Date().getFullYear() && month === (new Date().getMonth() + 1) && v === new Date().getDate()) {
            return `<td data-date="${year}/${month}/${v}" class="today calender">${v}</td>`
        }
        else if (v) {
            return `<td data-date="${year}/${month}/${v}" class="calender">${v}</td>`
        }
        else {
            return `<td data-date="" class="">${v}</td>`
        }
    });

    //------ 以下準備呈現在網頁上
    const allDataChunks = chunk(allData, 7);
    // console.log(allData, allDataChunks);
    const display = allDataChunks.map(v => `<tr>${v.join("")}</tr>`).join("");

    return display;
}

// 讀取選取日期並改變樣式的函式
function datepicker() {
    $('td').on('click', function () {
        if (this.className === 'calender') {
            $('td').css('background-color', '');
            $(this).css('background-color', 'yellow');
        }

        $("#pick").val($(this).data("date"));
    })
}

// 產生初始月曆
$('#data').html(genrateClander(year, month));
datepicker();

// 下拉選單變更時，重新產生月曆
$('#yy').on('change', function () {
    year = Number($('#yy').val());
    month = Number($('#mm').val());

    $('#data').html(genrateClander(year, month));
    datepicker();
})

// 下拉選單變更時，重新產生月曆
$("#mm").on('change', function () {
    year = Number($('#yy').val());
    month = Number($('#mm').val());

    $('#data').html(genrateClander(year, month));
    datepicker();
})
//** CONSTANTS **
const CALENDAR = document.getElementById("calendar");
const MONTH_NAMES = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
const DAY_NAMES = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
var CURRENT_DATE = new Date();

let selectedMonth = CURRENT_DATE.getMonth();
let availableMonths = [CURRENT_DATE.getMonth()];
var habitInx = 0;

let EXAMPLE_TASKS = {
    0: { color: "#d11141", label: "Wake up at 7:00", id: 1000 },
    1: { color: "#a22121", label: "Running", id:1001 }
}
function checkHabitsList() {
    var obj = window.localStorage.userHabits;
    if (obj == undefined && id != "" && habit != "") {
        localStorage.setItem("userHabits",
            JSON.stringify({ color: "#123654", label: habit, id: id }));
        EXAMPLE_TASKS = JSON.parse(window.localStorage.userHabits);
        //console.log("undefined");
    } else {
        EXAMPLE_TASKS = JSON.parse(window.localStorage.userHabits);
        //console.log("NOT undefined");
    }
}
function checkDelete() {
    var id = document.getElementById("deletedID").innerHTML;
    if (id != "") {
        var habitLists = JSON.parse(window.localStorage.userHabits);
        var i = 0
        for (i in habitLists) {
            if (habitLists[i].id == id) {
                //delete
                delete habitLists.habitLists[i];
            }
        }
    }
}
function checkHabit() {
    //get current id and label
    var habit = document.getElementById("lbl").innerHTML;
    var id = document.getElementById("id").innerHTML;
    var color = document.getElementById("color").innerHTML;
    var existFlag = 0;
    //loop to check id 
    var i = 0;
    for (i in EXAMPLE_TASKS) {
        if (EXAMPLE_TASKS[i].id == id) {
            existFlag = 1;
            habitInx = i;
            break;
        }
    }
    //Not Exist
    if (existFlag == 0 && habit != "" && id != "") {
        //Add in Example Tasks
        EXAMPLE_TASKS[Object.keys(EXAMPLE_TASKS).length] =
            { color: color, label: habit, id: id };
        localStorage.setItem("userHabits",
            JSON.stringify(EXAMPLE_TASKS));
        //Set Habit Index
        habitInx = (Object.keys(EXAMPLE_TASKS).length)-1;
    }
    
}
function init() {
    //checkDelete()
    checkHabitsList();
    checkHabit();
    checkLocalStorage();
    createDateInfo();
    createCalendarStructure();
    //createInfoStructure();
}

var checkLocalStorage = () => {
    if (window.localStorage.currentMonth === undefined || window.localStorage.data === undefined) {
        localStorage.setItem("currentMonth", selectedMonth);
        let currentData = {
            [selectedMonth]: {
                tasks: EXAMPLE_TASKS, data: {}
            }
        };
        localStorage.setItem("data", JSON.stringify(currentData));


    } else if (window.localStorage.currentMonth !== undefined && window.localStorage.currentMonth != CURRENT_DATE.getMonth()) {
        let previousData = JSON.parse(window.localStorage.data);

        if (getCurrentLocalStorageData() === undefined) {
            let confirmLoadPrevious =
                confirm("Do you want to load your previous habits?");

            let tasks = EXAMPLE_TASKS;

            if (confirmLoadPrevious && previousData[getPreviousMonth()] !== undefined)
                tasks = previousData[getPreviousMonth()].tasks;

            localStorage.setItem("currentMonth", CURRENT_DATE.getMonth());
            let currentData = { ...previousData, [CURRENT_DATE.getMonth()]: { tasks: tasks, data: {} } };

            localStorage.setItem("data", JSON.stringify(currentData));

        }
    }
    availableMonths = Object.keys(JSON.parse(window.localStorage.data));
}

var changeMonth = (month) => {
    selectedMonth = month;
    document.getElementById("monthLabel").innerText =
    MONTH_NAMES[selectedMonth];
    document.getElementById("calendar").innerText = "";
    CURRENT_DATE = new Date(CURRENT_DATE.getFullYear(), selectedMonth, 1);
   checkLocalStorage();
    createCalendarStructure();
    //checkMonthsAvailability();
    updateTasks();
    setCalendarData();
}

var updateTasks = () => {
    let inputs = document.querySelectorAll("#taskLabels input[type='text']");
    inputs.forEach((task, i) => {
        colorSquareChanged(i
            /*,
        document.getElementById("taskExample").children[0].style.background*/
        );
    taskNameChanged(i);
    })
}
var setCalendarData = () => {
    let days = document.querySelectorAll("#calendar .dayContainer");
    const startDay = getMonthDayStart();//6
    const monthDays = getDaysFromCurrentMonth();//30
    let currentData = getCurrentLocalStorageData().data;

    days.forEach((day, i) => {
        let daySquare = day.children; //circle
        let dayNumber = i - startDay;
        if (i < startDay || dayNumber >= monthDays) {
            if (i < startDay)
                day.classList.add("emptyDay");

            for (let square = 0; square < daySquare.length; square++) {
                daySquare[square].classList.add("hidden");
            };
        } else if (dayNumber < monthDays) {
            day.classList.remove("emptyDay");
            for (let j = 0; j < daySquare.length; j++) {
                daySquare[j].onclick = () => {
                    toggleTaskActive(dayNumber, habitInx, daySquare[j])
                };
                daySquare[0].classList.remove("hidden");
                daySquare[0].firstElementChild.innerText = j === 0 ?
                    (dayNumber < 9 ? `0${dayNumber + 1}` : dayNumber + 1) : "";
                setColorTaskBackground(
                    daySquare[0], habitInx, currentData[dayNumber][habitInx]);
            }
        }
    })
}

var numberOfHabits;
var createCalendarStructure = () => {
    const days = getDaysFromCurrentMonth();//28
    const startDay = getMonthDayStart();//0

    let currentData = getCurrentLocalStorageData() ?
        getCurrentLocalStorageData().data : {};

    for (let i = 0; i < 42; i++) {
        let dayContainer = document.createElement("div");
        dayContainer.className = "dayContainer";

        let dayNumber = i - startDay;//(0,1,..)
        let dayIsPositive = i >= startDay;
        if (currentData[dayNumber] === undefined && dayIsPositive)
            currentData[dayNumber] = {};

        //try to comment for loop
        /*for (let j = habitInx; j < 2; j++) {*/
        /*if (dayIsPositive 
            *//*&&(Object.keys(currentData[dayNumber]).length < habitInx+1)*//*) {
                currentData[dayNumber][habitInx] = false;
            }*/

            let task = document.createElement("div");
            let day = document.createElement("div");

            task.className = /*j !== 4 ? "square" :*/ "circle";
            day.className = "day";

            if (i >= startDay && dayNumber < days) {
                day.innerText = task.className === "circle" ? (dayNumber < 9 ? `0${dayNumber + 1}` : dayNumber + 1) : "";
                setColorTaskBackground(task, habitInx, currentData[dayNumber][habitInx]);
                task.onclick = () => { toggleTaskActive(dayNumber, habitInx, task) };
            } else {
                if (i < startDay) dayContainer.classList.add("emptyDay");
                task.classList.add("hidden");
            }

            task.appendChild(day);
            dayContainer.appendChild(task);
        /*}*/

        let thisMonthData = {
            [CURRENT_DATE.getMonth()]:
                { tasks: EXAMPLE_TASKS, data: currentData }
        };
        let data = { ...JSON.parse(window.localStorage.data), ...thisMonthData };
        localStorage.setItem("data", JSON.stringify(data));

        document.getElementById("calendar").appendChild(dayContainer);
    }
}

var createDateInfo = () => {
    checkMonthsAvailability();

    DAY_NAMES.forEach(day => {
        let dayLabel = document.createElement("span");
        dayLabel.textContent = day;
        document.getElementById("daysLabels").appendChild(dayLabel);
    });
    document.getElementById("monthLabel").innerText = MONTH_NAMES[selectedMonth];
}

var createInfoStructure = () => {
    let loadedTasks = getCurrentLocalStorageData().tasks;
    //need edit (i => index of task in example tasks)
    /*for (let i = 1; i < 2; i++) {*/
    let i = habitInx;
        let label = document.createElement("li");
        let input = document.createElement("input");
        let labelSquare = document.createElement("input");
        input.type = "text";
        labelSquare.type = "color";
        labelSquare.className = "squareLabel";


        let task = document.createElement("div");
        let day = document.createElement("div");

        task.className = /*i !== 4 ? "square" :*/ "circle";
        day.className = "day";

        if (loadedTasks[i] !== undefined) {
            input.value = loadedTasks[i].label;
            labelSquare.style.background = loadedTasks[i].color;
            labelSquare.value = rgbToHex(loadedTasks[i].color);
            task.style.background = loadedTasks[i].color;
        } else {
            input.value = EXAMPLE_TASKS[i].label;
            labelSquare.value = rgbToHex(EXAMPLE_TASKS[i].color)
            labelSquare.style.background = EXAMPLE_TASKS[i].color;
            task.style.background = EXAMPLE_TASKS[i].color;
        }

        input.onchange = (inputData) => { taskNameChanged(i, inputData) };
        labelSquare.onchange = (inputColor) => { colorSquareChanged(i, inputColor) };
        task.onclick = () => { labelSquare.click(); }

        label.appendChild(labelSquare);
        label.appendChild(input);
        document.getElementById("taskLabels").appendChild(label);

        task.appendChild(day);
        document.getElementById("taskExample").appendChild(task);
   /* }*/
}

var colorSquareChanged = (task, inputColor) => {
    let current = getCurrentLocalStorageData();
    let currentTasks = current.tasks;
    let value = inputColor === undefined ?
        currentTasks[task].color : inputColor.target.value;
    let currentItem = document.querySelector("#taskLabels input[type='color']");

    value = rgbToHex(value);
    currentItem.value = value;
    currentItem.style.background = value;
    document.getElementById("taskExample").children[0].style.background = value;

    currentTasks = {
        ...currentTasks,
        [task]: {
            color: value,
            label: document.querySelector("#taskLabels input[type='text']").value
        }
    };

    let thisMonthData = {
        [selectedMonth]:
        { tasks: currentTasks, data: current.data }
    };
    let data = { ...JSON.parse(window.localStorage.data), ...thisMonthData };
    localStorage.setItem("data", JSON.stringify(data));

    let allTasks = document.querySelectorAll("#calendar .dayContainer:not(.emptyDay)");
    current = getCurrentLocalStorageData();

    allTasks.forEach((square, task) => {
        let children = square.children;
        for (let i = habitInx; i < habitInx+1; i++) {
            if (current.tasks[i] !== undefined && current.data[task] !== undefined && current.data[task][i])
                children[0].style.background = current.tasks[i].color;
        }
    })

}

var taskNameChanged = (task, inputData) => {
    let current = getCurrentLocalStorageData();
    let currentTasks = current.tasks;

    let value = inputData === undefined ?
        currentTasks[task].label : inputData.target.value;
    let colorContainers = getTaskSquares();

    currentTasks = {
        ...currentTasks,
        [task]: { color: colorContainers[task].style.background, label: value }
    };

    document.querySelectorAll("#taskLabels input[type='text']")[task].value = value;
    let thisMonthData = {
        [selectedMonth]:
        { tasks: currentTasks, data: current.data }
    };
    let data = { ...JSON.parse(window.localStorage.data), ...thisMonthData };
    localStorage.setItem("data", JSON.stringify(data));
}

var getTaskStatus = (day, task) => {
    let currentData = getCurrentLocalStorageData().data;
    return currentData[day][task];
}

var setTaskStatus = (day, task, status) => {
    let currentData = getCurrentLocalStorageData().data;
    currentData[day][task] = status;
    console.log(currentData[day][task]);
    let thisMonthData = { [selectedMonth]: { tasks: getCurrentLocalStorageData().tasks, data: currentData } };
    let data = { ...JSON.parse(window.localStorage.data), ...thisMonthData };
    localStorage.setItem("data", JSON.stringify(data));
}

var setColorTaskBackground = (element, task, completed) => {
    let currentTasks = getCurrentLocalStorageData().tasks;

    if (currentTasks[task] !== undefined)
        element.style.background =
            completed ? currentTasks[task].color : "";
    else
        element.style.background =
            completed ? EXAMPLE_TASKS[task].color : "";
}

var toggleTaskActive = (day, task, element) => {
    let completed = getTaskStatus(day, task);
    console.log(completed);
    setTaskStatus(day, task, !completed);
    setColorTaskBackground(element, task, !completed);
}

var checkMonthsAvailability = () => {
    let nextMonth = document.getElementById("nextMonth");
    let previousMonth = document.getElementById("previousMonth");

    if (!availableMonths.includes(String(getNextMonth())))
        nextMonth.classList.add("hidden");
    else
        nextMonth.classList.remove("hidden");

    if (!availableMonths.includes(String(getPreviousMonth())))
        previousMonth.classList.add("hidden");
    else
        previousMonth.classList.remove("hidden");
}

//** UTILS **
var getDaysFromCurrentMonth = () => new Date(CURRENT_DATE.getFullYear(), selectedMonth + 1, 0).getDate();
var getMonthDayStart = () => {
    let startDay = new Date(CURRENT_DATE.getFullYear(), selectedMonth, 1).getDay();
    return startDay === 0 ? 6 : (startDay - 1);
}

var getCurrentLocalStorageData = () => JSON.parse(window.localStorage.data)[selectedMonth]/*[0/1/...]*/;

var getTaskSquares = () => document.querySelectorAll("#taskLabels > li input[type='color']");

var getPreviousMonth = () => {
    let month = selectedMonth - 1;
    return month < 0 ? 11 : month;
}

var getNextMonth = () => {
    let month = selectedMonth + 1;
    return month > 11 ? 0 : month;
}

var rgbToHex = (rgb) => {
    if (rgb.includes("#")) return rgb;
    rgb = rgb.replace(/(rgb)|\(|\)/g, '')
        .split(',')
        .map(val => Number(val));
    return rgb.reduce((acc, val) => acc + (0 + val.toString(16)).slice(-2), '#');
}

document.getElementById("nextMonth").onclick = () => { changeMonth(getNextMonth()) };
document.getElementById("previousMonth").onclick = () => { changeMonth(getPreviousMonth()) };

init();
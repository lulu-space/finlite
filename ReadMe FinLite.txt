ReadMe

Intro:
FinLite is a Windows Forms desktop application designed to help users manage their monthly income, expenses, and savings goals. 


OOP:
3 classes were created Expenses and Income (both override Schedule method) which Inherit From the Abstract Transaction class (contains methods set and get for dashboard frame fetching values, and an abstract method Schedule), That also Inherits from the ISchedulable Interface (only has void Schedule method)

MainForm.cs and Designer:
inherits from Form (an abstract container- built in). holds a list from type Transactions, and holds any created functions by the designer components (when double clicked), all designer components, and operations are in it,like asigning values, calculate savings, update/generate reports, exception handling, button actions, adding items. noticed they all have parameters: object Sender(to trigger an event), EventArgs e(to carry event data). 

lastly, challenges faced:
when error ocurrs, i've learned to never touch the [designer] file, it will erase all your component work desining, and hardly restore it by fixing the error then click rebuild project this partially restored my work sends all way back to the beggining. 

unecessary double clicking the designer components will create uneeded functions.


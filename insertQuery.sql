use SelfDevelopment


-----Business  4
insert into Articles(Title , Author , Text , Image , TopicID)
values('All You Need To Know About Invoice Discounting' , 'Harshal Katre' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Business\business2.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Business\business2.jpg' , Single_Blob) as i1),
4)

insert into Articles(Title , Author , Text , Image , TopicID)
values('A 5-Step Stretching Habit That Will Leave You Energized, Relaxed, and More Mobile' , 'Jessica Migala' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health2.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health2.jpg' , Single_Blob) as i1),
1)




-----------Education  2

insert into Articles(Title , Author , Text , Image , TopicID)
values('IMPORTANCE OF EDUCATION' , 'Ananya Mahapatra' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education1.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education1.jpg' , Single_Blob) as i1),
2)



insert into Articles(Title , Author , Text , Image , TopicID)
values('Study: Can Fitness Trackers and Apps Give Your Exercise Routine a Boost?' , 'Sari Harrar' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health1.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health1.jpg' , Single_Blob) as i1),
1)


insert into Articles(Title , Author , Text , Image , TopicID)
values('5 Ways to Avoid the COVID Slide (A Teacher’s Tips)' , 'AnnElise Hatjakes' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education3.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education3.jpg' , Single_Blob) as i1),
2)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Smart education' , 'Learning Liftoff' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education5.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education5.jpg' , Single_Blob) as i1),
2)

-----------------FOOD=3
insert into Articles(Title , Author , Text , Image , TopicID)
values('Keeping low-moisture foods safe' , 'Joshua Minchin' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food1.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food1.jpg' , Single_Blob) as i1),
3)


insert into Articles(Title , Author , Text , Image , TopicID)
values('How GST Affects Service Industry' , 'Harshal Katre' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Business\business3.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Business\business3.jpg' , Single_Blob) as i1),
4)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Oils and Fats: How Food Affects Health' , 'JOY BAUER' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food2.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food2.jpg' , Single_Blob) as i1),
3)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Fruit and Vegetable Juice: How Food Affects Health' , 'JOY BAUER' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food3.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food3.jpg' , Single_Blob) as i1),
3)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Health Benefits of Tea and Coffee' , 'JOY BAUER' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food4.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food4.jpg' , Single_Blob) as i1),
3)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Why School Choice is Important for Your Child’s Education' , 'Elizabeth Street' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education2.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Education\education2.jpg' , Single_Blob) as i1),
2)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Refined Grains: How Food Affects Health' , 'JOY BAUER' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food5.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food5.jpg' , Single_Blob) as i1),
3)

insert into Articles(Title , Author , Text , Image , TopicID)
values('This is your body on fast food' , 'Christy Brissette' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food6.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Food\food6.jpg' , Single_Blob) as i1),
3)


----------------------HEALTH=1


insert into Articles(Title , Author , Text , Image , TopicID)
values('Is It Safe to Go Back to the Gym?' , 'K. Aleisha Fetters' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health3.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health3.jpg' , Single_Blob) as i1),
1)

insert into Articles(Title , Author , Text , Image , TopicID)
values('6 Quick Tips for Running Your Best Marathon' , 'Brianna Majsiak' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health4.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health4.jpg' , Single_Blob) as i1),
1)

insert into Articles(Title , Author , Text , Image , TopicID)
values('Hot Yoga: Is It Good for You, What to Know Before You Go, and How Hot It Gets' , 'Becky Upham' , 
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health5.txt' , Single_Blob)as t1),
(select * from OPENROWSET( BULK 'E:\ITI\ASP_MVC\Project\Self-Improvement-Website\Articles\Health\health5.jpg' , Single_Blob) as i1),
1)
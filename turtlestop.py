import turtle

turtle.pensize(3) #Set pen thickness to 3 pixels

turtle.penup()
turtle.goto(20, -50)
turtle.begin_fill() #Begin to fill color in a shape
turtle.color("red")
turtle.setheading(30)
turtle.circle(50, steps = 6) #Draw a hexagon
turtle.end_fill() #Fill the shape

turtle.color("white")
turtle.penup()
turtle.goto(-35, -20)
turtle.pendown()
turtle.write("STOP", font = ("Times", 18, "bold"))
turtle.hideturtle()

turtle.done()

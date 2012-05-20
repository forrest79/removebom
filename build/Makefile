CXX   = c++

FILES = ../RemoveBOM-CPP/removebom.cpp

TARGET = ../bin/rmbom

build:
	$(CXX) -Wall -o $(TARGET) $(FILES)
	chmod +x $(TARGET)
	strip $(TARGET)

clean:
	rm $(TARGET)

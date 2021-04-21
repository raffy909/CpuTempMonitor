# CpuTempMonitor
Tiny cpu temperature monitor for windows

 ***REMEMBER TO RUN IT AS ADMIN***

# TLDR
This is a tiny program that allow monitoring of the cpu temperature on windows machines. 
The temperature reading is done via an embedded webserver so to view the cpu temp you need to navigate to the machine ip address at port 8888

Ex : http://127.0.0.1:8888

# Two Versions
The differences between the two versions is that one use HTTP requests to get the temps the other one uses Websockets

# Notes
There are no security features, once started anyone on the network can get the temps of the machine

# Used libs
- OpenHardwareMonitorLib : https://github.com/openhardwaremonitor/openhardwaremonitor
- EmbedIO : https://github.com/unosquare/embedio

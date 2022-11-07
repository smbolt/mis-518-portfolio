library('fpp2')
library('ggfortify')
library('ggplot2')
library('forecast')
library('tseries')
library('tidyverse')
library('rio')

rm(list=ls())
time <- Sys.time()
print(time)

# Load Data
setwd("C:/_csu/MIS581")
df <- read.csv("Daily_Consumption.csv", header = TRUE)
#print(head(df))
#print(tail(df))
Y <- ts(df[,2],start=c(2021,1),frequency=365)

#Preliminary Analysis

#Plot 1 - Raw Time Series Data Plot "Y"
autoplot(Y, ts.colour='#3366ff', ts.size=1) +
  labs(title="Plot 1: ICBS Raw System Utilization - 1/1/2021 to 9/30/2022",
       subtitle=paste("Printed:", time, sep=" "),
       y="System Utilization")


#Remove Trend and Plot "DY"
DY <- diff(Y)
autoplot(DY, ts.colour='#3366ff', ts.size=1) +
  labs(title="Plot 2: ICBS Trend Removed, System Utilization - 1/1/2021 to 9/30/2022",
       subtitle=paste("Printed:", time, sep=" "),
       y="System Utilization - Trend Removed")

ggseasonplot(DY) +
  geom_line(size = 1.0) +
  labs(title="Plot 3: ICBS Seasonality Detection, System Utilization - 1/1/2021 to 9/30/2022",
       subtitle=paste("Printed:", time, sep=" "),
       x="January 1, 2021 to September 30, 2022",
       y="System Utilization - Seasonality")

# Benchmark forecast (Seasonal naive) - Residual SD = 963.9749
sn <- snaive(DY)
print(summary(sn))
checkresiduals(sn)

# Exponential Smoothing Model - Residual SD = 667.2678
ets <- ets(Y)
print(summary(ets))
checkresiduals(ets)

# ARIMA model - Residual SD = 582.6191
arima <- auto.arima(Y, stepwise=FALSE, approximation=FALSE, trace=TRUE)
print(summary(arima))
checkresiduals(arima)

# Forecast with the ARIMA Model
fcst <- forecast(arima, h=1086)
autoplot(fcst,ts.size=0.5) +
  labs(title="Plot 5: Prophet Forecast - 4/15/2022 to 6/30/2025",
       subtitle=paste("Printed:", time, sep=" "),
       y="System Utilization")
print(summary(fcst))




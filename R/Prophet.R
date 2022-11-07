library(prophet)
library(tidyverse)
library(lubridate)
library(dplyr)
rm(list=ls())
time <- Sys.time()
print(time)

# Load Data
setwd("C:/_csu/MIS581")
df_all <- read.csv("Daily_Consumption.csv", header = TRUE)
df_all$ds <- mdy(df_all$ds)
df=filter(df_all,ds<'2022-04-15')
print(tail(df))

m <- prophet(df)
f <- make_future_dataframe(m, 1186)
#print(head(f))
#print(tail(f))

fcst1 <- predict(m, f)
tail(fcst1[c('ds','yhat','yhat_lower','yhat_upper')])

dyplot.prophet(m, fcst1) 


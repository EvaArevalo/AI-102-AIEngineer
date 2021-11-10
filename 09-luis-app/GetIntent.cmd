@echo off

rem Set values for your Language Understanding app
set app_id=c41dbb3f-141b-4872-9d0e-eca92e1acb68
set endpoint=https://australiaeast.api.cognitive.microsoft.com/
set key=5e3ff4d446b04942aab5cac433fcb8dfYOUR_KEY

rem Get parameter and encode spaces for URL
set input=%1
set query=%input: =+%

rem Use cURL to call the REST API
curl -X GET "%endpoint%/luis/prediction/v3.0/apps/%app_id%/slots/production/predict?subscription-key=%key%&log=true&query=%query%"
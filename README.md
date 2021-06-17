# DriverTripsReport
  This repo has two projects.
  1. DriverTrips - This is .Net Framework WebApi which takes the file from the client and generates the report as the reponse.
  2. InputFileUpload.zip - This is the UI app. It has the upload controls. Upload the input file and get the response. Due to size contraints I had to zip and push to Git.
  3. inputfile.txt - This is the sample input file.
  
Steps to Configure.
1. fetch and run the DriverTrips WebApi
2. Unzip the InputFileUpload.zip angular app and update the API_URL constant value with your WebAPI address.
3. Once both the apps are UP and running, click on choose file button and select the inputfile.txt and then click on upload button.
4. On click of upload it will show the driver trip reports.

Thanks,

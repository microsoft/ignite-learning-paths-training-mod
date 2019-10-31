# Demo Guide

## Demo 1 - Azure Monitor in Existing Resources

1. On overview, show the Http 5x, data in, data out, etc. and explain this is part of monitoring
2. Open log streaming and navigate the site, show the streaming
3. Explain Application Insights is a part of Azure Monitor and you’ll explore those details next
4. Note: logs turn off automatically after 12 hours

## Demo 2 - Application Insights

1. Navigate to Application Insights and show the overview
2. Click on the Application Map
3. Click on the SQL speed and in the right pane choose “investigate performance”
4. Show the results
5. Go to Live Metrics stream. Collapse “Outgoing requests” and “Overall Health.”
6. Navigate the site and show the results in Live Stream.
7. Show the Performance graph

## Demo 3 - Log Analytics

1. Open application insights
2. Click on Logs (Analytics)
3. Open Help -> Documentation -> Tutorials -> Log Queries
4. Go to “Sample queries” -> Reports failures -> Exceptions causing request failures
5. Explain the query
6. Show “Requests’ performance” -> response time trend
7. Show different options to plot, graph, etc.

## Demo 4 - Snapshot debugging

1. Navigate to Application Insights
2. Navigate to Failures
3. Drill into an operation on the right panel
4. Click on “drill into operations”
5. Click on an operation to open the snapshot
6. Click “open debug snapshot” in  the right
7. If necessary, add the debugger role
8. Optional: if you have VS Enterprise, download the snapshot and open it there
9. Explain it is a NuGet package added to the code

## Demo 5 - Deployment Slots

TBD
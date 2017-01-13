# DynamicLoader
<strong>DynamicLoader</strong> is a solution to load an assembly dynamically. This is a very cool practice for updating application at run-time.

If an assembly is loaded into the default application domain, it can not be unloaded from memory while the process is running. 
<br />
However, if you open a second application domain to load and execute the assembly, the assembly is unloaded when that application domain is unloaded. Use this technique to minimize the working set of long-running processes that occasionally use large DLLs. 
<br />
We can also use this technique to isolate those modules that are often modified. So we can implement the application that must run for long periods without restarting.

<strong>Reference</strong>
<br />
https://msdn.microsoft.com/en-us/library/system.appdomain(v=vs.110).aspx
<br />
http://www.dofactory.com/net/proxy-design-pattern

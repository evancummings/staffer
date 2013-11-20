desc "Run NUnit tests"
nunit do |nunit|
	nunit.command = "NUnit/nunit-console.exe"
	nunit.assemblies = "assemblies/TestSolution.Tests.dll"
end
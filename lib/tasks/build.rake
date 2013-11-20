require 'fileutils'

desc "build the first solution file next to the rake file"
msbuild :build => :clean do |msb|
  msb.solution = Dir["*.sln"].first()
  msb.verbosity = :quiet 
end

desc "Clean up build artifacts"
task :clean do
  Dir["**/bin"].each do |path|
    base =  File.expand_path(File.join(path, ".."))
    FileUtils.rm_rf(File.join(base, "obj"))
    FileUtils.rm_rf(File.join(base, "bin"))
  end
end


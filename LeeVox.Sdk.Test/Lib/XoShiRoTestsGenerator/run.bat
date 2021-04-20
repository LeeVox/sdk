@echo off

rem build
call mvn clean dependency:copy-dependencies package

rem run generator
call java -cp "target/dependency/dsiutils-2.6.17.jar;target/dependency/fastutil-8.5.4.jar;target/dependency/fastutil-core-8.5.4.jar;target/dependency/commons-math3-3.6.1.jar;target/generator-1.0.jar" com.leevox.random.xoshiro.generator.app

@echo on
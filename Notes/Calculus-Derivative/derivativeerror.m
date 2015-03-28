NET.addAssembly('C:\Users\Artem\Documents\GitHub\Mathos-Project\Mathos\bin\Debug\Mathos.dll');
table = [];

syms x
df = diff(sin(x));
a= 10
val = subs(df,a);


% Double has precision 15-16 digits: https://msdn.microsoft.com/en-us/library/678hzkk9.aspx
for i=1:30
    value = Mathos.Calculus.DifferentialCalculus.FirstDerivative(@(d) sin(d), a,10^(-i));
    row = [10^(-i) val value abs(value-val)];
    table=[table;row];
end
table;
ind = table(:,1);
dep = table(:,3);


loglog(ind,dep)
title('sin(x)')
SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>

// IMPORTS { java : <http://www.emftext.org/java> 
// <../../org/urdad/language/someOtherLanguage/metamodel/someOtherLanguage.genmodel> 
// WITH SYNTAX java <../../org/urdad/language/someOtherLanguage/metamodel/someOtherLanguage.cs>}


START Model,ServiceRequirement

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"Model" COLOR #7F0055, BOLD;
	"ResponsibilityDomain" COLOR #7F0055, BOLD;
	"Query" COLOR #7F0055, BOLD;
	"Constraint" COLOR #7F0055, BOLD;
	"Condition" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"from" COLOR #7F0055, BOLD;
	"to" COLOR #7F0055, BOLD;
	"many" COLOR #7F0055, BOLD;
	"BasicDataType" COLOR #7F0055, BOLD;
	"DataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"abstract" COLOR #7F0055, BOLD;
	"has" COLOR #7F0055, BOLD;
	"Variable" COLOR #7F0055, BOLD;
	"ofType" COLOR #7F0055, BOLD;
	"Constant" COLOR #7F0055, BOLD;
	"ValueOf" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"attribute" COLOR #7F0055, BOLD;
	"association" COLOR #7F0055, BOLD;
	"aggregate" COLOR #7F0055, BOLD;
	"component" COLOR #7F0055, BOLD;
	"QualityRequirement" COLOR #7F0055, BOLD;
	"isRequiredBy" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"checks" COLOR #7F0055, BOLD;
	"raises" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"ensures" COLOR #7F0055, BOLD;
	"use" COLOR #7F0055, BOLD;
	"toAddress" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"ServiceContract" COLOR #7F0055, BOLD;
	"undoneVia" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"realizes" COLOR #7F0055, BOLD;
	"doSequential" COLOR #7F0055, BOLD;
	"choice" COLOR #7F0055, BOLD;
	"else" COLOR #7F0055, BOLD;
	"doConcurrent" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"Concurrency" COLOR #7F0055, BOLD;
	"wait" COLOR #7F0055, BOLD;
	"until" COLOR #7F0055, BOLD;
	"create" COLOR #7F0055, BOLD;
	"set" COLOR #7F0055, BOLD;
	"equalTo" COLOR #7F0055, BOLD;
	"add" COLOR #7F0055, BOLD;
	"remove" COLOR #7F0055, BOLD;
	"requestService" COLOR #7F0055, BOLD;
	"with" COLOR #7F0055, BOLD;
	"yields" COLOR #7F0055, BOLD;
	"on" COLOR #7F0055, BOLD;
	"raiseException" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"forAll" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)* 
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | dataTypes | servicesContracts | services | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	Query ::= "Query" (name[])? (queryExpression);
	
	Constraint ::= "Constraint" (name[])? (constraintExpression)? 
	  ("(" (annotations)*")")?;	
	
	Condition ::= "Condition" (name[])? (constraintExpression)?
	  ("(" (annotations)*")")?;
	
	QualityConstraint ::= "QualityConstraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;

	RangeMultiplicity ::= "from" minOccurs[] "to" maxOccurs[];
	Many ::= "many";
	BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (constraints)*")")? ("(" (annotations)*")")?;  
	
	DataStructure ::= "DataStructure" name[] ("is" superType[])? "{"
	  ("abstract" "=" abstract[])?
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";

	Variable ::= "Variable" name[] "ofType" type[];

	Constant ::= "Constant" value['"','"'];

	VariableReference ::= "ValueOf" variable[];
	  
	Exception ::= "Exception" name[] ("is" superType[])? "{" 
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";
	
	Attribute ::= (multiplicityConstraint)? "attribute" name[] "ofType" type[];
	Association ::= (multiplicityConstraint)? "association"  name[] "ofType" relatedType[]; 
	Aggregation ::= (multiplicityConstraint)? "aggregate" (multiplicityConstraint)? name[] "ofType" relatedType[]; 
	Composition ::= (multiplicityConstraint)? "component" (multiplicityConstraint)? name[] "ofType" relatedType[];
	 
	QualityRequirement ::= "QualityRequirement" name[] (constraintExpression)? 
		"isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
	  
	PreCondition ::= "PreCondition" name[] ("checks" constraintExpression)? 
      "raises" exception[] "isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
	  
	PostCondition ::= "PostCondition" name[] ("ensures" constraintExpression)? 
		"isRequiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;
 		
	ServiceRequirement ::= "use" requiredService[]
	 	"toAddress" "("(usedToAddress[])*")"
		("if" (condition))? ("(" (annotations)*")")?;
	
	ServiceContract ::= "ServiceContract" name[] "{"
	 (preConditions | postConditions)*
	 (qualityRequirements)*
	 ("undoneVia" inverseService[])?
	 "Request" request   
	 "Result" result 
	  ("(" (annotations)*")")?"}";
	  
	Service ::= "Service" name[] "realizes" realizedContract[] "{"
		"Request" (requestVariable)
		(serviceRequirements)*
		(activity)
	"}";  
	
	ActivitySequence ::= "doSequential" "{" (activities)* "}"; 

	If ::= "if" (condition) (activity);

	Choice ::= "choice" "{" (conditionalActivities)* ("else" (elseActivity)?) "}";
	
	ConcurrentActivity ::= "doConcurrent" (activity) ("blocking" "=" blocking[])?;
	
	Concurrency ::= "Concurrency" "{" (concurrentActivities)* "}"; 
	
	Wait ::= "wait" "until" (until);
	
	Create ::= "create" (producedVariable);
	
	Assign ::= "set" target "equalTo" source;
	Add ::= "add" source "to" target;
	Remove ::= "remove" target;
	
	RequestService ::= "requestService" requestedService[] "with" requestVariable[] 
			("yields" (producedVariable))? 
		("{" 
			(exceptionHandlers)*
		"}")?;

	ExceptionHandler ::= "on" exception[] (activity);
		
	RaiseException ::= "raiseException" exception[] ("with" exceptionVariable[])?;	
		
	ReturnResult ::= "returnResult"	resultVariable[];
		
	While ::= "while" (condition) "do" (activity);	
		
	ForAll ::= "forAll" (query) "do" (activity); 	

	Annotation ::= "Note" language[] ":" content['"','"'];
}
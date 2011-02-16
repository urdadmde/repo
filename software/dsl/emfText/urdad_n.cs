SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"Exception" COLOR #7F0055, BOLD;
	"Model" COLOR #7F0055, BOLD;
	"ResponsibilityDomain" COLOR #7F0055, BOLD;
	"Services" COLOR #7F0055, BOLD;
	"Constraint" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"requires" COLOR #7F0055, BOLD;
	"raises" COLOR #7F0055, BOLD;
	"when" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"Process" COLOR #7F0055, BOLD;
	"ActivitySequence" COLOR #7F0055, BOLD;
	"ConcurrentActivities" COLOR #7F0055, BOLD;
	"ConcurrentActivity" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"then" COLOR #7F0055, BOLD;
	"check" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[] !0
	 (responsibilityDomains)*
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{" !1
		("Data types" ":" (dataTypes)* )? !1
		("Functional constraints" ":" !2 
		  (functionalConstraints)*  )? !1
		("Quality constraints" ":" !2 
		  (qualityConstraints)* )? !1
		("Services" ":" !2 
		  (services)* )? !1
		("Responsibility domains" ":" !2 
		  (responsibilityDomains)* )? !1
	  	("(" (annotations)*")")?
	"}" !0;

	Expression ::= "(" language [] ":" expressionString['"','"'] ")";
	
	GeneralConstraint ::= "Constraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;
	
	BooleanExpression ::=  language [] ":" expressionString['[',']'];

	RangeMultiplicity ::= "["minOccurs[] "," maxOccurs[] "]";
	BasicDataType ::= "Basic data type" name[]	  
	  ("(" (annotations)*")")?;
	
	DataStructure ::= "Data structure" name[] ("is" superType[])? 
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?;
	Exception ::= "Exception" name[] ("is" superType[])? 
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?;
	
	Attribute ::= "- has attribute" name[] "of type" type[];
	Association ::= "- is associated with" name[] "of type" relatedType[] (multiplicityConstraint)?; 
	Aggregation ::= "- has" name[] "of type" relatedType[] (multiplicityConstraint)?; 
	Composition ::= "- contains" name[] "of type" relatedType[] (multiplicityConstraint)?;
	 
	QualityRequirement ::= name[]   
		"is required by" requiredBy[]
		qualityConstraint[] 
	  ("(" (annotations)*")")?;
	  
	QualityConstraint ::= name[] ":" (qualityExpression);	  
		
	FunctionalRequirement ::= name[]  
		" is required by" requiredBy[] 
	 	functionalConstraint[]  
	  ("(" (annotations)*")")?;
	
	PreCondition ::= "PreCondition" name[]
		("requires" requiredService[])?
		 "raises" exception[]
		("when" condition)?
	  ("(" (annotations)*")")?;

	PostCondition ::= "PostCondition" name[]
		("requires" requiredService[])?
		("undone by" inverseService[])? 
	  ("(" (annotations)*")")?;
	
	Service ::= "Service" name[] 
	 ("Functional requirements:" (functionalRequirements )* )? 
	 ("Quality requirements:" (qualityRequirements )*)? 
	 "Request:" request   
	 "Result:" result 
	 (process)? 
	  ("(" (annotations)*")")?;
	 
	Process ::= "Process" processActivity ("(" (annotations)*")")?;

	ActivitySequence ::= "ActivitySequence" "{" (activities)* "}";
	ConcurrentActivities ::= "ConcurrentActivities" "{" (activities)* "}";
	ConcurrentActivity ::= "ConcurrentActivity" ("(" "blocking" "=" blocking[]")")?
		activity;
	Switch ::= "Branching:" "{" (conditionalActivities)* "}";
	
	While ::= "while" condition  activity;
		
	ConditionalActivity ::= "if" condition "then" activity;
	
	PreConditionActivity ::= "check" preCondition[]  
		("Request constraints:" (requestContraints)*)? 
		("Exception constraints:" (exceptionContraints)*)? 
		("(" (annotations)*")")?;
		
	
	PostConditionActivity ::= "do"  postCondition[]  
		("Request constraints:" (requestContraints)*)? 
		("Undo request constraints:" (inverseRequestContraints)*)? 
		("(" (annotations)*")")?;
	
	PrePostConditionActivity ::=  
		"ensure that" preCondition[] 
		"do" postCondition[] 
		("Request constraints:" (requestContraints)*)? 
		("Exception constraints:" (exceptionContraints)*)? 
		("Undo request constraints:" (inverseRequestContraints)*)? 
		("(" (annotations)*")")?;

	ReturnResultActivity ::= "return result"   
		("Result constraints:" (resultContraints)*)? 
		("(" (annotations)*")")?;
		
	Annotation ::= "Note" language[] ":" content['"','"'];
	
}
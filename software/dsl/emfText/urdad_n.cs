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
}

RULES {
	Model ::= "model" name[] !0
	 (responsibilityDomains)*
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "responsibilityDomain" name[] "{" !1
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
	
	DataStructure ::= "Data structure" name[] ("is" superType[])? !1 
	  (attributes)* !1 (associations)* 
	  ("(" (annotations)*")")?;
	Exception ::= "Exception" name[] ("is" superType[])? !1 
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
	
	PreCondition ::= "preCondition" name[]
		("requires" requiredService[])?
		 "raises" exception[]
		("when" condition)?
	  ("(" (annotations)*")")?;

	PostCondition ::= "postCondition" name[]
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
	 
	Process ::= "process" processActivity ("(" (annotations)*")")?;

	ActivitySequence ::= "activitySequence" "{" (activities)* "}";
	ConcurrentActivities ::= "concurrentActivities" "{" (activities)* "}";
	ConcurrentActivity ::= "concurrentActivity" ("(" "blocking" "=" blocking[]")")?
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